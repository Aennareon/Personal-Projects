using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AserraderoL : MonoBehaviour
{
    [Header("Building Atributes")]
    public Aserradero aserraderoData;
    [Header("BuildingLogic Atributes")]
    public bool productionUpdated;
    public float oldPrValue;

    private void Awake()
    {
        aserraderoData.economy = FindObjectOfType<EconomyVault>();
    }
    private void Start()
    {

        oldPrValue = aserraderoData.woodGenerated;
        aserraderoData.economy.ingresoMadera += aserraderoData.woodGenerated;
        aserraderoData.setResidentsRoleIngeniero(aserraderoData.residents);
    }

    private void Update()
    {
        if (aserraderoData.productionON)
        {
            checkProduction();
        }
    }

    public void checkProduction()
    {
        if (oldPrValue != aserraderoData.woodGenerated)
        {
            productionUpdated = false;
        }

        if (!productionUpdated)
        {
            float prdDiff = oldPrValue - aserraderoData.woodGenerated;

            if (prdDiff < 0)
            {
                Debug.Log(prdDiff);
                aserraderoData.economy.ingresoMadera += Mathf.Abs(prdDiff);
                Debug.Log("Madera Out");
                oldPrValue = aserraderoData.woodGenerated;
            }
            if (prdDiff > 0)
            {
                Debug.Log(prdDiff);
                aserraderoData.economy.ingresoMadera -= Mathf.Abs(prdDiff);
                Debug.Log("Madera Out");
                oldPrValue = aserraderoData.woodGenerated;
            }
            productionUpdated = true;
            Debug.Log("Produccion Cambiada");
        }


    }
}
