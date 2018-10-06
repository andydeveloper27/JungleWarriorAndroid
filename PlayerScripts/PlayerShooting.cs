using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// manages player shooting
public class PlayerShooting : MonoBehaviour {

	public Transform m_player;

	public GameObject m_crossHair;

	public PauseMenu pausemenu; // pausemenu
	public LevelComplete levelcomplete; // level complete
	public AudioManager audiomanager; // audiomanager

	public GameObject m_bullet; // bullet

	public Transform m_muzzle; // muzzle

	public Camera m_fpsCam; // fps cam

	public AudioSource m_audioSource; // audio source

	public AudioClip m_shootingSound; // shooting sound
	public AudioClip m_emptyGunSound; // empty gun sound

	public ParticleSystem m_muzzleFlash; // muzzleflash

	public Text m_bulletCounter; // bullet counter

	public float m_bulletsRemaining; // bullets remaining
	public float m_bulletDamage; // bullet damage
	public float m_range; // range

	private float m_bulletSpeed; // bullet speed

	private float m_nextFire; // next fire
	private float m_fireRate; // fire rate

	// Use this for initialization
	void Start () {

		m_nextFire = 0f; // nextfire = 0
		m_fireRate = 1f; // fire rate - 1

		//m_audioSource = GetComponent<AudioSource> ();

		m_bulletSpeed = 50.0f; // bullet speed

		m_bulletDamage = 20f; // bullet damage

		m_bulletsRemaining = 30f; // bullets remaining

		m_range = 100f; // range

		// checks if bullet counter is available or not
		if (m_bulletCounter.GetComponent<Text> () == null) {

			Debug.Log ("Bullet counter not found");
		}

		// checks if muzzle flash is available or not
		if (m_muzzleFlash.GetComponent<ParticleSystem> () == null) {

			Debug.Log ("MuzzleFlash not found");
		}

		// checks if camera is available or not
		if (m_fpsCam.GetComponent<Camera> () == null) {

			Debug.Log ("FPS Camera not found");
		}
	}
	
	// Update is called once per frame
	void Update () {

		// bullet counter converted to text
		m_bulletCounter.GetComponent<Text> ().text = m_bulletsRemaining.ToString ();

		// when mouse is down and no bullets
		if (Input.GetMouseButtonDown (0) && m_bulletsRemaining == 0) {

			audiomanager.PlayAudio (m_audioSource, m_emptyGunSound); // plays audio
		}
	}

	// shoot function
	public void Shoot(){
		
		if (m_bulletsRemaining > 0 && Time.time > m_nextFire &&
		    !pausemenu.m_gameIsPaused && !levelcomplete.m_levelIsComplete && Time.timeScale == 1) {

			m_nextFire = Time.time + m_fireRate; // delay with the shooting

			// Checks for bullet
			if (m_bullet == null) {

				Debug.Log ("Bullet not found"); // Logs error
			}

			// instantiates bullet
			GameObject bullet = Instantiate (m_bullet);

			// projects bullet from muzzle position
			bullet.transform.position = transform.position + Camera.main.transform.forward * 2;

			// bullet from muzzle rotation
			//bullet.transform.rotation = m_muzzle.transform.rotation;

			// rigidbody
			Rigidbody rb = bullet.GetComponent<Rigidbody> ();

			rb.AddForce (transform.forward * m_bulletSpeed, ForceMode.Impulse);

			Destroy (bullet, 3); // Destroys bullet

			m_bulletsRemaining--; // bullet decrement

			m_muzzleFlash.Play (); // muzzle flash play

			// Checks for audio source
			if (m_audioSource != null) {

				audiomanager.PlayAudio (m_audioSource, m_shootingSound); // plays sound
			} else {

				Debug.Log ("AudioSource not found"); // logs error
			}
		}
	}
}