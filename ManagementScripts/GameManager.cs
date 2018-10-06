using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	int m_highScore; // highscore
	int m_score; // score

	// awake
	void Awake(){

		DontDestroyOnLoad (this.gameObject); // object does not destroy

		// deletes score when scene 1 begins
		if (SceneManager.GetActiveScene().buildIndex == 1) {

			ResetPlayerPref ("score"); // resets playerpref
		}
	}

	// updates high score
	public void HighScoreUpdated(){

		m_highScore = m_score;
	}

	// increase score
	public void IncreaseScore(int value){

		m_score += value; // new score
	}

	// loads score with specified name
	public void SetScoreToPlayerPref(int value){

		value = PlayerPrefs.GetInt ("score"); // gets playerpref

		m_score = value; // sets score to value
	}

	// loads score with specified name
	public void SetHighScoreToPlayerPref(int value){

		value = PlayerPrefs.GetInt ("HighScore"); // gets playerpref

		m_highScore = value; // sets highscore to value
	}


	// sets highscore
	public void SetHighScore(int highscore){

		m_highScore = highscore; // high score
	}

	// gets high score
	public int GetHighScore(){

		return m_highScore; // return high score
	}

	// gets high score
	public int GetScore(){

		return m_score; // return score
	}

	// resets playerpref
	public void ResetPlayerPref(string key){

		PlayerPrefs.DeleteKey (key); // delete score
	}

	// sets player prefs
	public void SetPlayerPrefs(string key, int value){

		PlayerPrefs.SetInt (key, value); // sets int
	}
}