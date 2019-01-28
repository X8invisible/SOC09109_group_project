using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Image fuelBar;
    public int maxFuel;
    public int minFuel;
    private Car car;

    void Start()
    {
        car = GameObject.FindWithTag("Car").GetComponent<Car>();
    }
    void Update()
    {
        fuelBarDisplay(car.FuelCount);
    }
    public void fuelBarDisplay(float currentFuel){
        float currentFuelPercentage;
        currentFuelPercentage = currentFuel / (maxFuel - minFuel);
        fuelBar.fillAmount = currentFuelPercentage;
    }
}
