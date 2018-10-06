using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// time management script
public class TimerScript : MonoBehaviour {

	private bool m_playAudio = true; // play audio set to true

	public Text m_timerText; // timer text
	public Text m_gameOverText; // game over text

	public int m_timer; // timer

	public LevelComplete levelcomplete; // level complete
	public BackToMainMenu backtomainmenu; // back to main menu

	public AudioSource m_audioSource; // audio source
	public AudioClip m_gameOverAudio; // game over audio

	// Use this for initialization
	void Start () {

		Cursor.visible = false; // disables cursor

		Time.timeScale = 1; // time is running

		m_timer = 350; // time set to 150

		m_gameOverText.enabled = false; // game over text set to false

		InvokeRepeating ("Count", 0.0f, 1.0f); // invokes count function to keep timer ticking
	}
	
	// Update is called once per frame
	void Update () {

		m_timerText.GetComponent<Text> ().text = m_timer.ToString (); // timer text set to timer
	}

	// keeps timer counting
	void Count(){

		// if timer is 0
		if (m_timer == 0 && m_playAudio) {

			m_timer = 0; // keeps timer at 0

			m_gameOverText.enabled = true; // game over text enabled

			backtomainmenu.m_backToMainMenu.enabled = true; // back to main menu button enabled

			m_audioSource.PlayOneShot (m_gameOverAudio); // game over audio playing

			m_playAudio = false; // audio now set to false so it dosent continue playing

			Time.timeScale = 0; // time stopped running

			Cursor.visible = true; // enables cursor

			Cursor.lockState = CursorLockMode.None; // enables cursor to move
		} 
		else {

			m_timer--; // otherwise, keep decrementing timer
		}

		// if level has been completed
		if (levelcomplete.m_levelIsComplete) {

			CancelInvoke (); // cancel timer
		}
	}
}
