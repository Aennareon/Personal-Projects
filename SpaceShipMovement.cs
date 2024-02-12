using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpaceShipMovement : MonoBehaviour
{
    [Header("Físicas")]
    public Rigidbody rb;
    private Vector3 moveVelocity;

    [Header("Propulsores")]
    [Range(0,100)]
    public float mainTpush;
    [Range(-100, 100)]
    public float SideTpush;
    [Range(-100, 100)]
    public float verSideTpush;
    [Range(-100, 100)]
    public float rotSideTpush;

    [Header("Motor")]
    public float TotalPower;
    public float uPower;
    public float unPower;

    [Header("Consumo Potencia")]
    public float mainEngineE;
    private float mCurrentT = 0;
    public float sideEngineE;
    private float sideCurrentT = 0;
    public float verEngineE;
    private float verCurrentT = 0;
    public float rotEngineE;
    private float rotCurrentT = 0;


    [Header("Acceleración/Reservas E")]
    public float acceleration;

    private void Update()
    {
        //PowerManagment
        powerManager(); 

        //Main engine
        mainEngineController();

        //side engine
        secEngineController(SideTpush, sideCurrentT, Vector3.up);

        //vertical engine
        secEngineController(verSideTpush, verCurrentT, Vector3.right);

        //Rotation engine
        secEngineController(rotSideTpush, rotCurrentT, Vector3.forward);
    }
    public void powerManager()
    {
        uPower = Mathf.Abs(mainEngineE + Mathf.Abs(sideEngineE) + Mathf.Abs(verEngineE) + Mathf.Abs(rotEngineE));
        unPower = Mathf.Abs(TotalPower - Mathf.Abs(uPower));

        acceleration = unPower;

        mainEngineE = Mathf.Abs(mainTpush);
        sideEngineE = Mathf.Abs(SideTpush);
        verEngineE = Mathf.Abs(verSideTpush);
        rotEngineE = Mathf.Abs(rotSideTpush);


    }
    public void mainEngineController()
    {
        //Get foward vector
        Quaternion rotation = transform.rotation;
        Vector3 forwardDirection = rotation * Vector3.forward;
        forwardDirection.Normalize();

        //Calc Speed 
        mCurrentT = Mathf.MoveTowards(mCurrentT, mainTpush, Time.deltaTime * acceleration);
        float targetSpeed = mCurrentT / 10;
        moveVelocity = forwardDirection * targetSpeed;
        rb.velocity = new Vector3(moveVelocity.x, moveVelocity.y, moveVelocity.z);
    }
    public void secEngineController(float secEngineT, float secEngineCT, Vector3 axys)
    {
        secEngineCT = Mathf.MoveTowards(secEngineCT, secEngineT, Time.deltaTime * acceleration);
        float rotationAmount = secEngineCT/10;
        Quaternion deltaRotation = Quaternion.Euler(axys * rotationAmount);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }







}
