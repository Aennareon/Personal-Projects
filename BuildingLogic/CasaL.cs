using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CasaL : MonoBehaviour
{
    [Header("Building Atributes")]
    public Casa casaData;
    [Header("BuildingLogic Atributes")]
    public bool productionUpdated;
    public bool populationDone;
    public float oldResidents;

    private void Awake()
    {
        casaData.economy = FindObjectOfType<EconomyVault>();

    }

    private void Update()
    {
        if (!populationDone)
        {
            assignPopulation();
            checkPopulation(oldResidents, casaData.residents, casaData.economy.numeroDesempleados);
        }
    }
        

    public void checkPopulation(float oldValue, float newValue, float valueToChange)
    {
        if (oldValue != newValue)
        {
            productionUpdated = false;
        }
        if (!productionUpdated)
        {
            float prdDiff = oldValue - newValue;
            if (prdDiff < 0)
            {
                valueToChange -= Mathf.Abs(prdDiff);
                oldValue = newValue;
            }
            if (prdDiff > 0)
            {
                valueToChange += Mathf.Abs(prdDiff);
                oldValue = newValue;
            }
            productionUpdated = true;
        }
    }

    public void assignPopulation()
    {
        if (casaData.economy.numeroDesempleados >= casaData.maxHousePpl)
        {
            casaData.economy.numeroDesempleados -= casaData.maxHousePpl;
            casaData.residents = casaData.maxHousePpl;
            casaData.economy.numeroNoAsignados += casaData.residents;
            populationDone = true;
        }
        if (casaData.economy.numeroDesempleados < casaData.maxHousePpl)
        {
            casaData.residents = casaData.economy.numeroDesempleados;
            casaData.economy.numeroDesempleados = 0;
            casaData.economy.numeroNoAsignados += casaData.residents;
            populationDone = true;
        }
    }
}
