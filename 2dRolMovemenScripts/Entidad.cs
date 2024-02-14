using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entidad : MonoBehaviour
{
    public float vida;
    public float velocidadMovimiento;
    public float velocidadActual;
    public float aceleracion;
    public float deceleracion;
    public bool seleccionado;


    public void movimiento(Vector3 target)
    {
        if(transform.position != target)
        {
            Debug.Log("Entidad en movimiento");
            velocidadActual = Mathf.MoveTowards(velocidadActual, velocidadMovimiento, Time.deltaTime * aceleracion);
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * velocidadActual);
        }

        if(Vector2.Distance(transform.position, target) <= 0.5)
        {
            Debug.Log("Entidad parando");
            velocidadActual = Mathf.MoveTowards(velocidadActual, 0, Time.deltaTime * deceleracion);
        }

        if(transform.position == target)
        {
            velocidadActual = 0;
            Debug.Log("Entidad en target");
        }

       
    }

    


}
