using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class buildingStats
{
    [Header("Estadísticas Edificio")]
    public float health;
    public float residents;
    public float goldGenerated;
    public float woodMant;
    public float metalMant;
    public EconomyVault economy;

    private float oldPrValue;
    private bool productionUpdated;

    public void setGoldIncome()
    {
        oldPrValue = goldGenerated;
        economy.ingresoEdificios += goldGenerated;
    }

    public void checkGoldProduction()
    {
        if (oldPrValue != goldGenerated)
        {
            productionUpdated = false;
        }

        if (!productionUpdated)
        {
            float prdDiff = oldPrValue - goldGenerated;

            if (prdDiff < 0)
            {
                Debug.Log(prdDiff);
                economy.ingresoEdificios += Mathf.Abs(prdDiff);
                oldPrValue = goldGenerated;
            }
            if (prdDiff > 0)
            {
                Debug.Log(prdDiff);
                economy.ingresoEdificios -= Mathf.Abs(prdDiff);
                oldPrValue = goldGenerated;
            }
            productionUpdated = true;
            Debug.Log("Produccion Cambiada");
        }


    }

    public void setResidentsRoleSoldier(float residents)
    {
        economy.numeroNoAsignados -= residents;
        economy.numeroSoldados += residents;
    }
    public void setResidentsRoleTrabajador(float residents)
    {
        economy.numeroNoAsignados -= residents;
        economy.numeroTrabajadores += residents;
    }
    public void setResidentsRoleIngeniero(float residents)
    {
        economy.numeroNoAsignados -= residents;
        economy.numeroIngenieros += residents;
    }
}

