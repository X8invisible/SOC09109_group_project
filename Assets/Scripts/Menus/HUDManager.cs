using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    //Used for HUD fuel count
    public Image fuelBar;
    public int maxFuel;
    public int minFuel;

    public void fuelBarDisplay(float currentFuel){
        float currentFuelPercentage;
        currentFuelPercentage = currentFuel / (maxFuel - minFuel);
        fuelBar.fillAmount = currentFuelPercentage;
    }
}
