using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// manages when the player has completed the level
public class LevelComplete : MonoBehaviour {

	public Image m_crossHair; // crosshair

	public Canvas m_canvasLevelComplete; // canvas for level completion
	public Canvas m_canvasGameComplete; // canvas for game complete

	public EnemyCount enemycount; // enemycount
	public PauseMenu pausemenu; // pausemenu
	public GameManager gamemanager; // scorescript
	public ScoreScript scorescript;

	public bool m_gameIsComplete; // game complete bool
	public bool m_levelIsComplete; // level complete bool
	public bool m_nextLevelLoaded; // next level bool

	public AudioSource m_audioSource; // audio source
	public AudioClip m_gameCompleteAudio; // game complete audio

	public AudioManager audiomanager; // audio manager

	// Use this for initialization
	void Start () {

		m_gameIsComplete = false; // game complete set to false
		m_levelIsComplete = false; // level is not complete
		m_nextLevelLoaded = false; // next level has not been loaded

		m_canvasLevelComplete.enabled = false; // canvas is not enabled

		m_canvasGameComplete.enabled = false; // canvas not enabled

		if (SceneManager.GetSceneByName ("Scene2").isLoaded) {

			Time.timeScale = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {

		// if next level has been loaded
		if (m_nextLevelLoaded) {

			pausemenu.ResumeGame (); // resumes game
		}

		// when level is complete
		if (m_levelIsComplete || m_gameIsComplete) {

			Time.timeScale = 0; // time stops

			audiomanager.m_audioSource.Stop ();

			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true; // cursor is visible
		} 
	}

	// upon colliding with collider
	void OnTriggerEnter(Collider _collider){

		// when enemy count is 0 and player has collided with the helicopter
		if (enemycount.m_enemiesRemaining == 0 && _collider.transform.tag == "Player") {

			m_levelIsComplete = true; // level is complete

			m_crossHair.enabled = false; // cross hair disabled

			m_canvasLevelComplete.enabled = true; // level complete canvas enabled

			audiomanager.PlayAudio(m_audioSource, m_gameCompleteAudio); // plays victory audio
		}
		else if(enemycount.m_enemiesRemaining == 0 && _collider.transform.tag == "Player" && 
			SceneManager.GetSceneByName("Scene2").isLoaded){

			Time.timeScale = 0; // time stops

			m_gameIsComplete = true; // level is now complete

			m_crossHair.enabled = false; // cross hair disabled

			m_canvasGameComplete.enabled = true; // game complete canvas enabled

			audiomanager.PlayAudio(m_audioSource, m_gameCompleteAudio); // plays victory audio
		}
	}

	// back to main menu
	public void BackToMainMenu(){

		gamemanager.SetPlayerPrefs ("HighScore", gamemanager.GetHighScore());
		//PlayerPrefs.SetInt ("HighScore", scorescript.m_highScore); // sets highscore

		gamemanager.ResetPlayerPref ("score");
		//PlayerPrefs.DeleteKey ("score");

		SceneManager.LoadScene ("MainMenu"); // goes to main menu scene
	}

	// next level
	public void NextLevel(){
	
		SceneManager.LoadScene ("Scene2"); // goes to scene2

		Time.timeScale = 1; // time stops
	}
}