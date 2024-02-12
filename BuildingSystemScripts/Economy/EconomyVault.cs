using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EconomyVault : MonoBehaviour
{
    [Header("Población y Clases Sociales")]
    public float numeroCiudadanos = 0;
    public float numeroNoAsignados = 0;
    public float numeroNiños = 0;
    public float numeroTrabajadores = 0;
    public float numeroIngenieros = 0;
    public float numeroSoldados = 0;
    public float numeroDesempleados = 0;
    [Header("Ingresos Recursos")]
    public float ingresoNiños;
    public float ingresoTrabajadores;
    public float ingresoIngenieros;
    public float ingresoSoldados;
    public float ingresoDesempleados;
    public float ingresoEdificios;
    public float ingresosTotales;
    public float ingresoMadera;
    public float ingresoMetal;
    [Header("Gastos Poblacion")]
    public float gastoNiños;
    public float gastoTrabajadores;
    public float gastoIngenieros;
    public float gastoSoldados;
    public float gastoDesempleados;
    public float gastosTotales;
    public float gastoMetal;
    public float gastoMadera;
    [Header("Caja fuerte y Almacenes")]
    public float oro;
    public float madera;
    public float metal;
    [Header("Elementos de control")]
    public bool noDesempleados;
    public bool noNoAsignados;
    [Header("TurnSystemTest")]
    public bool passTurnNow;
    public float monthTimer;

    private void Update()
    {
        turnPassTest();
    }

    public void populationManager()
    {
        numeroCiudadanos = numeroNiños + numeroTrabajadores + numeroIngenieros + numeroSoldados + numeroDesempleados;
        gastosTotales = (gastoNiños * numeroNiños + gastoTrabajadores * numeroTrabajadores + gastoIngenieros * numeroIngenieros + gastoSoldados * numeroSoldados + gastoDesempleados * numeroDesempleados);
        ingresosTotales = (ingresoNiños * numeroNiños + ingresoTrabajadores * numeroTrabajadores + ingresoIngenieros * numeroIngenieros + ingresoSoldados * numeroSoldados + ingresoDesempleados * numeroDesempleados + ingresoEdificios) - gastosTotales;

        oro += ingresosTotales;
        madera += ingresoMadera - gastoMadera;
        metal += ingresoMetal - gastoMetal;
    }


    public void turnPassTest()
    {
        monthTimer += Time.deltaTime;
        if(monthTimer >= 15)
        {
            passTurnNow = true;
            monthTimer = 0;
        }

        if (passTurnNow)
        {
            populationManager();
            passTurnNow = false;
        }
    }

}

