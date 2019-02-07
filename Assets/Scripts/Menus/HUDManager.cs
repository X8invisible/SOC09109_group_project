using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Image fuelBar;
    public int maxFuel;
    public int minFuel;
    public Image[] hearts;
    private int healthPerHeart =2;
    private Car car;

    void Start()
    {
        car = GameObject.FindWithTag("Car").GetComponent<Car>();
    }
    void Update()
    {
        fuelBarDisplay(car.FuelCount);
        heartDisplay(car.Lives);
    }
    public void fuelBarDisplay(float currentFuel){
        float currentFuelPercentage;
        currentFuelPercentage = currentFuel / (maxFuel - minFuel);
        fuelBar.fillAmount = currentFuelPercentage;
    }
    void heartDisplay(float life){
        int health = (int)life;
        int heart = health / healthPerHeart;
        int heartFill = health % healthPerHeart;
        if(health % healthPerHeart ==0){
            //full health would give index out of bounds
            if(heart == hearts.Length){
                hearts[heart-1].fillAmount =1;
                return;
            }
            //in case you heal up, set previous heart to full
            if(heart > 0){
                hearts[heart].fillAmount=0;
                hearts[heart-1].fillAmount=1;
            }else   //no health
            {
                hearts[heart].fillAmount =0;
            }
            return;
        }
        hearts[heart].fillAmount = heartFill /(float)healthPerHeart;

    }

}
