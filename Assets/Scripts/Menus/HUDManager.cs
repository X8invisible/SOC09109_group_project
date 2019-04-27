using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    public Image fuelBar;
    public int maxFuel;
    public int minFuel;
    public Image[] hearts;
    private int healthPerHeart =4;
    private Car car;
    public Text scoreText;
    public Text gameOverScore;
    public GameObject gameOverPanel;
    private bool over = false;
    void Start()
    {
        car = GameObject.FindWithTag("Car").GetComponent<Car>();
    }

    void Update()
    {
        fuelBarDisplay(car.FuelCount);
        heartDisplay(car.Lives);
        scoreDisplay(car.Score);

        if((car.FuelCount <= 0 || car.Lives <= 0)&& !over)
            {
                gameOver(car.Score);
                over = true;
            }
        
    }

    public void fuelBarDisplay(float currentFuel)
    {
        float currentFuelPercentage;
        currentFuelPercentage = currentFuel / (maxFuel - minFuel);
        fuelBar.fillAmount = currentFuelPercentage;
    }

    void gameOver(float score)
    {
        gameOverPanel.SetActive(true);
		Time.timeScale = 0f;
        int s = (int)score;
        gameOverScore.text = "Final Score: " + s;
    }
    void scoreDisplay(float score)
    {
      int s = (int)score;

      scoreText.text = "Score: " + s;
    }

    void heartDisplay(float life)
    {
        int health = (int)life;
        int heart = health / healthPerHeart;
        int heartFill = health % healthPerHeart;
        for(int i=0;i<hearts.Length;i++)
        {
            if(i*4>health)
                hearts[i].fillAmount=0;
        }
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
    public void LoadMenu()
	{
		Time.timeScale = 1f;
        over = false;
		SceneManager.LoadScene("MainMenu");
	}
    public void ReloadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        over = false;
    }
}
