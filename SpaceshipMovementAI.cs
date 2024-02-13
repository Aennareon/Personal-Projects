using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpaceshipMovementAI : MonoBehaviour
{
    public SpaceShipMovement movementManager;
    public Transform Target;


    private void Update()
    {
        fowardMovement();
        lateralMovement();
        balanceoNave();
       
    }

    //Calcular variables
    float CalculateTotalDistance(Vector3 pointA, Vector3 pointB)
    {
        return Vector3.Distance(pointA, pointB);
    }
    float CalculateHorizontalDistance(Vector3 position1, Vector3 position2)
    {
        // Ignorar la diferencia en el eje Y
        Vector2 pos1XZ = new Vector2(position1.x, position1.z);
        Vector2 pos2XZ = new Vector2(position2.x, position2.z);

        // Calcular la distancia horizontal
        float distance = Vector2.Distance(pos1XZ, pos2XZ);

        return distance;
    }
    float CalculateDistanceY(Vector3 pointA, Vector3 pointB)
    {
        return pointA.y - pointB.y;
    }
    float CalculateSignedAngle(Vector3 position1, Vector3 forward1, Vector3 position2)
    {

        float angle = Vector3.Angle(forward1, position2);
        return angle;
    }
    
    //movimiento adelante/atras y vertical
    public void fowardMovement()
    {
        float distance = CalculateHorizontalDistance(transform.position, Target.position);

        if(distance > 1)
        {
            movementManager.mainTpush = 30;
            verticalMovement();
        }
        if(distance < -1)
        {
            movementManager.mainTpush = -30;
            verticalMovement();
        }
        if(distance < 1 && distance > -1)
        {
            movementManager.mainTpush = 0;

            setXOrientDefault();
        }
    }
    public void verticalMovement()
    {
        float distance = CalculateDistanceY(transform.position, Target.position);
        float angle = CalculateSignedAngle(transform.position, transform.forward, Target.position);
        float calc = angle * Mathf.Sign(distance);

        if(distance > 1 || distance < -1)
        {
            if (calc > 1)
            {
                movementManager.verSideTpush = 20;
            }
            if (calc < -1)
            {
                movementManager.verSideTpush = -20;
            }
            if (calc < 1 && calc > -1)
            {
                movementManager.verSideTpush = 0;
            }
        }
        else
        {
            setXOrientDefault();
        }
        
    }
    public void setXOrientDefault()
    {
        
        if(transform.rotation.x > 0.01)
        {
            movementManager.verSideTpush = -5;
        }else
        {
            if (transform.rotation.x < -0.01)
            {
                movementManager.verSideTpush = 5;
            }
            else
            {
                if(transform.rotation.x > -0.01 && transform.rotation.x < 0.01)
                {
                    movementManager.verSideTpush = 0;
                }
            }
        }
    }

    //movimiento rotacion
    public void balanceoNave()
    {
        if(movementManager.SideTpush != 0)
        {
            if(movementManager.SideTpush > 0)
            {
                movementManager.rotSideTpush = -1;
            }

            if (movementManager.SideTpush < 0)
            {
                movementManager.rotSideTpush = 1;
            }
        }
        else
        {
            if(transform.rotation.z != 0)
            {
                if (transform.rotation.z > 0.01)
                {
                    movementManager.rotSideTpush = -1;
                }
                else
                {
                    if (transform.rotation.z < -0.01)
                    {
                        movementManager.rotSideTpush = 1;
                    }
                    else
                    {
                        if (transform.rotation.z > -0.01 && transform.rotation.z < 0.01)
                        {
                            movementManager.rotSideTpush = 0;
                        }
                    }
                }
            }
            else
            {
                movementManager.rotSideTpush = 0;
            }
        }
    }
    public int GetRotationDirection()
    {
        if (Target != null)
        {

            Vector3 targetDirection = (Target.position - transform.position).normalized;
            float angle = Vector2.SignedAngle(new Vector2(transform.forward.x, transform.forward.z), new Vector2(targetDirection.x, targetDirection.z));

            if (angle > 0)
            {
                return 1; 
            }
            else if (angle < 0)
            {
                return -1; 
            }
            else
            {
                return 0; 
            }
        }
        else
        {
            return 0; 
        }
    }
    public void lateralMovement()
    {
        int sign = GetRotationDirection();

        if (sign > 0)
        {
            movementManager.SideTpush = -10;
        }
        if(sign < 0)
        {
            movementManager.SideTpush = 10;
        }
        if(sign == 0)
        {
            movementManager.SideTpush = 0;
        }
    }
}
