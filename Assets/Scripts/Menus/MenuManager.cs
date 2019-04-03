using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Class for controlling the Main Menu Buttons
public class MenuManager : MonoBehaviour
{
	public GameObject optionsPanel;
	public GameObject mainPanel;
	private bool panelState = true;
	//Function for switching from main menu scene to the game start
	public void StartGame()
	{
		//NOTE. for now it will be using the "Main" scene, name to be changed if the scene file is renamed
		SceneManager.LoadScene("Main");
	}
	public void OptionsClick()
	{
		mainPanel.SetActive(!panelState);
		optionsPanel.SetActive(panelState);
		panelState = !panelState;
	}
	public void ExitGame()
	{
		Application.Quit();
	}
}
