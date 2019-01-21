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
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}
	void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}

	//will send you back to main menu
	public void LoadMenu()
	{
		//time needs to be resumed after you exit the scene
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
	}
}
