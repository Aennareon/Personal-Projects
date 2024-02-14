using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorOrdenes : MonoBehaviour
{
    private Entidad entidad;
    public bool startTest;
    private Camera mainCamera;
    public bool movementOn;
    public Vector2 movementTarget;

    private void Start()
    {
        entidad = GetComponent<Entidad>();
        mainCamera = Camera.main;
    }
    private void Update()
    {
        moverATarget();
    }

    public void moverATarget()
    {

        if(entidad.seleccionado == true && Input.GetMouseButtonDown(1))
        {
            movementTarget = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            movementOn = true;
        }
        if (movementOn)
        {
            entidad.movimiento(movementTarget);
        }
    }

}
