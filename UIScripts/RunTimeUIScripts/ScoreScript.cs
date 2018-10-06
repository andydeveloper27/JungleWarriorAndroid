using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

// manages the score system
public class ScoreScript : MonoBehaviour{

	public GameManager gamemanager; // game manager

	public GameObject m_helicopter; // helicopter

	public GameObject m_player; // player

	public EnemyCount enemycount; // enemy count

	public TimerScript timerscript; // timer script

	public LevelComplete levelcomplete; // levelcomplete

	public int m_score; // score
	public Text m_scoreText; // score text

	public int m_scoreFinal; // final score
	public Text m_scoreFinalText; // final score text

	public int m_highScore; // HIGH SCORE
	public Text m_highScoreText; // final score text

	public Text m_newHighScore; // final score text

	public AudioSource m_audioSource; // audiosource
	public AudioClip m_audioClip; // audioclip
	public AudioClip m_newHighScoreAudio; // high score audio

	public AudioManager audiomanager; // audio manager

	// Use this for initialization
	void Start () {

		gamemanager.SetScoreToPlayerPref (m_score);
		gamemanager.SetHighScoreToPlayerPref (m_highScore);

		m_newHighScore.enabled = false; // new score text disabled

		m_scoreFinalText.enabled = false; // final text disabled
	}
	
	// Update is called once per frame
	void Update () {

		int highscore = gamemanager.GetHighScore ();
		int score = gamemanager.GetScore ();

		// score text set to score
		if (m_scoreText != null) {
			
			m_scoreText.GetComponent<Text> ().text = score.ToString (); // sets to string
		}

		// final text set to final score int
		if (m_scoreFinalText != null) {
			
			m_scoreFinalText.GetComponent<Text> ().text = m_scoreFinal.ToString (); // sets to string
		}

		// checks for text to be null
		if (m_highScoreText != null) {
			
			m_highScoreText.GetComponent<Text> ().text = highscore.ToString (); // sets to string
		}

		float distance = Vector3.Distance (m_player.transform.position, m_helicopter.transform.position);

		// if score is higher than high score
		if (score > highscore && SceneManager.GetActiveScene().buildIndex == 2 && distance < 5.0f) {

			gamemanager.HighScoreUpdated ();
			//m_highScore = m_score; // new highscore
		}

		// when enemies remaining is 0 and level is complete
		if (enemycount.m_enemiesRemaining == 0 && levelcomplete.m_levelIsComplete) {

			Time.timeScale = 0; // timescale set to 0

			m_scoreFinal = score * timerscript.m_timer; // final score is score * the current time

			m_scoreFinalText.enabled = true; // enables final score text

			gamemanager.SetPlayerPrefs ("score", m_scoreFinal);
			//PlayerPrefs.SetInt ("score", m_scoreFinal); // sets score

			// final score higher than score
			if (m_scoreFinal > highscore && SceneManager.GetSceneByName("Scene2").isLoaded) {
				
				highscore = m_scoreFinal; // new highscore 

				gamemanager.SetPlayerPrefs ("HighScore", highscore);
				//PlayerPrefs.SetInt ("HighScore", m_highScore); // sets new high score

				// Audio plays after level complete audio has finished
				if (!levelcomplete.m_audioSource.isPlaying) {

					StartCoroutine (NewHighScore ()); // starts text flash
				}
			}
		}
	}
		
	// new high score text flash
	IEnumerator NewHighScore(){

		audiomanager.PlayAudio (m_audioSource, m_newHighScoreAudio); // plays audio

		m_newHighScore.enabled = true; // sets text to true

		yield return new WaitForSeconds (1f); // waits

		m_newHighScore.enabled = false; // sets text to false

		yield return new WaitForSeconds (0.5f); // waits

		m_newHighScore.enabled = true; // sets text to true

		yield return new WaitForSeconds (1f); // waits

		m_newHighScore.enabled = false; // sets text to false

		m_audioSource.Stop (); // stops audio
	}
}