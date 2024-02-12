using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AyuntamientoL : MonoBehaviour
{
    public Ayuntamiento ayuntamientoData;
    private float oldResidents;
    private bool popSet;

    private void Awake()
    {
        ayuntamientoData.economy = GetComponent<EconomyVault>();
    }
    private void Start()
    {

        ayuntamientoData.setGoldIncome();
        ayuntamientoData.economy.numeroNoAsignados = ayuntamientoData.residents;
        ayuntamientoData.setResidentsRoleSoldier(ayuntamientoData.residents);
        ayuntamientoData.economy.numeroNoAsignados = 0;
    }

    private void Update()
    {
        ayuntamientoData.checkGoldProduction();
        checkPopulation(oldResidents, ayuntamientoData.residents, ayuntamientoData.economy.numeroDesempleados);
    }

    public void checkPopulation(float oldValue, float newValue, float valueToChange)
    {
        if (oldValue != newValue)
        {
            popSet = false;
        }
        if (!popSet)
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
            popSet = true;
        }
    }
}
