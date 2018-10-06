using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages enemy shooting 
public class EnemyShooting : MonoBehaviour {

	public PauseMenu pausemenu; // pause menu

	public EnemyAI enemyAI; // enemy ai

	public GameObject m_bullet; // bullet
	public Transform m_bulletSpawn; // bullet spawning point

	public AudioManager audiomanager; // audiomanager

	public AudioSource m_audioSource; // audio source
	public AudioClip m_enemyShootingAudio; // enemy shooting audio

	private float m_fireSpeed = 2f; // firing speed
	private float m_trackFire = 0f; // fire tracking

	private float m_fireBurstTime = 100f; // burst time
	private float m_fireBurstRandomAdd = 0.5f; // random burst

	private float m_burstPauseTime = 10f; // pause time
	private float m_burstPauseRandomAdd = 1; // random pause

	private float m_trackBurst; // burst tracker
	private float m_trackBurstPause; // pause tracker

	// Use this for initialization
	void Start () {
		
		m_trackBurst = m_fireBurstTime; // sets track burst to fire burst time
	}
	
	// Update is called once per frame
	void Update () {

		// when attacking player, not paused and time scale is running
		if (enemyAI.m_attackingPlayer && !pausemenu.m_gameIsPaused && Time.timeScale == 1) {

			// when audio is not playing
			if (!m_audioSource.isPlaying) {

				audiomanager.PlayAudio (m_audioSource, m_enemyShootingAudio);
			}

			// when track fire is more than 0
			if (m_trackFire > 0) {

				m_trackFire -= Time.deltaTime * m_fireSpeed; // track fire * fire speed
			}

			// when track burst is more than 0 and track fire is less than 0
			if (m_trackFire <= 0 && m_trackBurst > 0) {

				Instantiate (m_bullet, m_bulletSpawn.position, m_bulletSpawn.rotation); // instantiates bullet from spawn point

				m_trackFire = 1; // track fire set to 1
			}

			// when track burst is more than 0
			if (m_trackBurst > 0) {
			
				m_trackBurst -= Time.deltaTime; // track burst decreases

				// track burst less than or equal to 0
				if (m_trackBurst <= 0) {

					m_trackBurstPause = m_burstPauseTime + (Random.value * m_fireBurstRandomAdd); // track burst pause randomizer
				}
			}

			// track burst pause more than 0
			if (m_trackBurstPause > 0) {

				m_trackBurstPause -= Time.deltaTime; // track burst pause decrement

				// track burst pause less than or equal to 0
				if (m_trackBurstPause <= 0) {

					m_trackBurstPause = m_fireBurstTime + (Random.value * m_burstPauseRandomAdd); // track burst pause randomizer
				}
			}
		}
	}
}
