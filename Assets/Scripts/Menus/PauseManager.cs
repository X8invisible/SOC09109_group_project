using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
	//global variable required to see if the game is paused(might be needed in future for other mechanics except pausing time)
	public static bool gameIsPaused = false;
	//this is the panel named 'PauseMenu' in the scene that needs to be visible or hidden depending on stituation
	public GameObject pauseMenuUI;
	public GameObject optionsPanel;
	public GameObject backgroundPanel;
	private bool panelState = true;
    // Update is called once per frame
    void Update()
    {
		//game can be paused using escape key, a button could be added in future and just included in the if statement
    if(Input.GetKeyDown(KeyCode.Escape))
		{
			if (gameIsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
    }

	//this function is public cause it's needed for the resume button as well
	public void Resume()
	{
		Debug.Log("----pause menu----");
		pauseMenuUI.SetActive(false);
		optionsPanel.SetActive(false);
		backgroundPanel.SetActive(false);
		panelState = true;
		Time.timeScale = 1f;
		gameIsPaused = false;
	}
	public void Pause()
	{
		Debug.Log("----pause menu----");
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}
		public void OptionsClick()
	{
		Debug.Log("----options menu----");
		pauseMenuUI.SetActive(!panelState);
		optionsPanel.SetActive(panelState);
		panelState = !panelState;
	}
	public void BackgroundClick()
{
	Debug.Log("----background menu----");
	optionsPanel.SetActive(panelState);
	backgroundPanel.SetActive(!panelState);
	panelState = !panelState;
}
	//will send you back to main menu
	public void LoadMenu()
	{
		Debug.Log("----load menu----");
		//time needs to be resumed after you exit the scene
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
	}
}
