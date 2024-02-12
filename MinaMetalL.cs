using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaMetalL : MonoBehaviour
{
    [Header("Building Atributes")]
    public MetalMine mineData;
    [Header("BuildingLogic Atributes")]
    public bool productionUpdated;
    public float oldPrValue;
    public float oldWoodUpkeepValue;

    private void Awake()
    {
        mineData.economy = FindObjectOfType<EconomyVault>();
    }
    private void Start()
    {

        oldPrValue = mineData.metalGenerated;
        oldWoodUpkeepValue = mineData.woodMant;
        mineData.economy.ingresoMetal += mineData.metalGenerated;
        mineData.economy.gastoMadera += mineData.woodMant;
        mineData.setResidentsRoleIngeniero(mineData.residents);
    }

    private void Update()
    {
        if (mineData.productionON)
        {
            checkProduction();
        }
    }

    public void checkProduction()
    {
        if (oldPrValue != mineData.metalGenerated || oldWoodUpkeepValue != mineData.woodMant)
        {
            productionUpdated = false;
        }

        if(!productionUpdated)
        {
            float prdDiff = oldPrValue - mineData.metalGenerated;
            float woodUDiff = oldWoodUpkeepValue - mineData.woodMant;

            if(prdDiff < 0)
            {
                Debug.Log(prdDiff);
                mineData.economy.ingresoMetal += Mathf.Abs(prdDiff) ;
                oldPrValue = mineData.metalGenerated;
            }
            if (prdDiff > 0)
            {
                Debug.Log(prdDiff);
                mineData.economy.ingresoMetal -= Mathf.Abs(prdDiff);
                oldPrValue = mineData.metalGenerated;
            }
            if(woodUDiff < 0)
            {
                Debug.Log(woodUDiff);
                mineData.economy.gastoMadera += Mathf.Abs(woodUDiff);
                oldWoodUpkeepValue = mineData.woodMant;
            }
            if(woodUDiff > 0)
            {
                Debug.Log(woodUDiff);
                mineData.economy.gastoMadera -= Mathf.Abs(woodUDiff);
                oldWoodUpkeepValue = mineData.woodMant;
            }
            productionUpdated = true;
            Debug.Log("Produccion Cambiada");
        }
        
   
    }

}
