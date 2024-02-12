using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceshipMovementAI : MonoBehaviour
{
    public SpaceShipMovement movementManager;
    public Transform Target;

    private void Update()
    {
        fowardMovement();
    }

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

    public void fowardMovement()
    {
        float distance = CalculateHorizontalDistance(transform.position, Target.position);

        if(distance > 5)
        {
            movementManager.mainTpush = 10;
            verticalMovement();
        }
        if(distance < -5)
        {
            movementManager.mainTpush = -10;
            verticalMovement();
        }
        if(distance < 5 && distance > -5)
        {
            Debug.Log("parado");
            movementManager.mainTpush = 0;

            setXOrientDefault();
        }
    }

    public void verticalMovement()
    {
        float distance = CalculateDistanceY(transform.position, Target.position);
        float angle = CalculateSignedAngle(transform.position, transform.forward, Target.position);
        float calc = angle * Mathf.Sign(distance);
        Debug.Log(calc);

        if(calc > 1)
        {
            movementManager.verSideTpush = 5;
        }
        if(calc < -1) 
        {
            movementManager.verSideTpush = -5;
        }
        if(calc < 1 && calc > -1)
        {
            movementManager.verSideTpush = 0;
        }
    }

    public void setXOrientDefault()
    {
        Debug.Log(transform.rotation.x); 
        if(transform.rotation.x > 1)
        {
            movementManager.verSideTpush = -5;
        }

        if (transform.rotation.x < -1)
        {
            movementManager.verSideTpush = 5;
        }

        else
        {
            movementManager.verSideTpush = 0;
        }
    }

}
