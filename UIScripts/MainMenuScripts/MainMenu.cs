using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// manages main menu
public class MainMenu : MonoBehaviour {

	public GameManager gamemanager;
	public Canvas m_levelSelectCanvas; // level select canvas
	public Canvas m_controlsCanvas; // controls canvas
	public Canvas m_mainMenuCanvas; // main menu canvas

	public AudioSource m_audioSource; // audio source

	public AudioManager audiomanager;

	// Use this for initialization
	void Start () {

		gamemanager.ResetPlayerPref ("score");
		//PlayerPrefs.DeleteKey ("score");

		// Checks for main menu canvas
		if (m_mainMenuCanvas != null) {

			m_mainMenuCanvas.enabled = true; // main menu enabled
			m_levelSelectCanvas.enabled = false; // level select not enabled
			m_controlsCanvas.enabled = false; // controls not enabled

		} else {

			Debug.Log ("Main menu not found"); // Logs error
		}
	}
	
	// Update is called once per frame
	void Update () {

		Cursor.visible = true; // curose is visible
	}

	// plays the game
	public void PlayGame(){

		// Checks if the scene is valid
		if (!SceneManager.GetSceneByName ("Scene1").IsValid ()) {
			
			SceneManager.LoadScene ("Scene1"); // loads scene1

			Time.timeScale = 1; // Time is running
		} 
		else {

			Debug.Log ("Could not find Scene 1"); // logs error
		}
	}

	// level select
	public void LevelSelect(){

		m_mainMenuCanvas.enabled = false; // main menu canvas set to false
		m_levelSelectCanvas.enabled = true; // level select enabled
		m_controlsCanvas.enabled = false; // controls canvas disabled
	}

	// controls function
	public void Controls(){

		m_mainMenuCanvas.enabled = false; // main menu canvas set to false
		m_levelSelectCanvas.enabled = false; // level select canvas set to false
		m_controlsCanvas.enabled = true; // controls canvas set to false
	}

	// exit function
	public void Exit(){

		Application.Quit (); // quits application
	}

	public void BackToTheMainMenu(){

		m_mainMenuCanvas.enabled = true; // main menu enabled
		m_levelSelectCanvas.enabled = false; // level select not enabled
		m_controlsCanvas.enabled = false; // controls canvas not enabled
	}

	// loads scene 1
	public void LoadScene1(){

		// Checks if the scene is valid
		if (!SceneManager.GetSceneByName ("Scene1").IsValid ()) {

			SceneManager.LoadScene ("Scene1"); // loads scene1

			Time.timeScale = 1; // Time is running
		} 
		else {

			Debug.Log ("Could not find Scene 1"); // logs error
		}
	}

	// loads scene2
	public void LoadScene2(){

		// Checks if the scene is valid
		if (!SceneManager.GetSceneByName ("Scene2").IsValid ()) {

			SceneManager.LoadScene ("Scene2"); // loads scene1

			Time.timeScale = 1; // Time is running

			gamemanager.ResetPlayerPref ("score");
			//PlayerPrefs.DeleteKey ("score"); // deletes score
		} 
		else {

			Debug.Log ("Could not find Scene 2"); // logs error
		}
	}
}
