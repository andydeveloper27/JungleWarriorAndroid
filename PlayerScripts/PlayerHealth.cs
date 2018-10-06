using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// manages player health
public class PlayerHealth : MonoBehaviour {

	public float m_health; // health

	public Image m_healthBar; // health bar

	public Text m_gameOverText; // gameover text

	// start
	void Start(){

		m_gameOverText.enabled = false; // game over text not enabled
	}
	
	// Update is called once per frame
	void Update () {

		m_healthBar.fillAmount = (m_health / 100); // health bar amount

		// when health is more than 99.9f
		if (m_health >= 99.9f) {

			m_healthBar.color = Color.green; // health bar is green
		}

		// when health is less than 75
		if (m_health <= 75f) {
			
			m_healthBar.color = Color.yellow; // health bar is yellow
		} 

		// when health is less than 50
		if (m_health <= 50f) {

			m_healthBar.color = Color.red; // health bar is red
		}

		// when health is 0
		if (m_health <= 0) {

			PlayerDied (); // player died
		}
	}

	// player died
	void PlayerDied(){

		Cursor.visible = true; // cursoe visible

		Time.timeScale = 0; // time stops

		m_health = 0; // keeps health at 0

		m_gameOverText.enabled = true; // game over text enabled
	}
}