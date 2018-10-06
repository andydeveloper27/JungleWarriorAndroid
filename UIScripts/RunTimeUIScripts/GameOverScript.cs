using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// manages game over 
public class GameOverScript : MonoBehaviour {

	private bool m_playAudio = true; // makes sure audio only plays once rather than continously through the update function

	public PlayerHealth playerhealth; // player health

	public AudioSource m_audioSource; // audio source
	public AudioClip m_gameOverAudio; // game over audio

	public AudioManager audiomanager; // audiomanager

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// when player health is 0 
		if (playerhealth.m_health <= 0 && m_playAudio) {

			audiomanager.PlayAudio (m_audioSource, m_gameOverAudio); // audio plays

			m_playAudio = false; // audio now false

			Time.timeScale = 0; // time is not running
		}
	}
}