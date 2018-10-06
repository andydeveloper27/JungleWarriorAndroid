using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// manages back to main menu button
public class BackToMainMenu : MonoBehaviour {

	public PauseMenu pausemenu; // pausemenu

	public LevelComplete levelcomplete;

	public PlayerHealth playerhealth; // playerhealth

	public Canvas m_backToMainMenu; // back to main menu canvas

	// Use this for initialization
	void Start () {

		Time.timeScale = 1; // time is running

		m_backToMainMenu.enabled = false; // canvas not enabled
	}
	
	// Update is called once per frame
	void Update () {

		// Checks for canvsa
		if (m_backToMainMenu == null) {

			Debug.Log ("Back to main menu Canvas not found"); // logs error
		}

		// when health is 0
		if (playerhealth.m_health == 0) {

			Cursor.lockState = CursorLockMode.None; // enables cursor to move

			m_backToMainMenu.enabled = true; // back to main menu canvas enabled
		} 
	}

	// back to main menu button function
	public void BackToMainMenuButton(){

		// Checks if scene is valid
		if (!SceneManager.GetSceneByName ("MainMenu").IsValid ()) {

			SceneManager.LoadScene ("MainMenu"); // load main menu
		} 
		else {

			Debug.Log ("Main menu scene could not be found"); // Reports log
		}
	}

	// restart level button function
	public void RestartLevel(){

		SceneManager.LoadScene(SceneManager.GetActiveScene().name); // load current level again

		Time.timeScale = 1; // time is running
	}
}