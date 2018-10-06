using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

	public AudioSource m_audioSource; // audio source

	public bool m_track1IsPlaying = false; // track playing
	public bool m_track2IsPlaying = false; // track playing
	public bool m_track3IsPlaying = false; // track playing
	public bool m_track4IsPlaying = false; // track playing

	public AudioClip m_track1; // track 1
	public AudioClip m_track2; // track 2
	public AudioClip m_track3; // track 3
	public AudioClip m_track4; // track 4

	public static AudioManager instance;

	// Use this for initialization
	void Awake () {

		if(instance == null){           // If the static var is null
			instance = this;            // assign the script to it
			DontDestroyOnLoad(gameObject); // Keep the script over scene loadings
		}
		else if(instance != this){        // if the variable is not this script
			Destroy(gameObject);            // Destroy the object
		}
	}

	// start
	void Start(){

		// Checks for tracks available
		if (m_track1 == null || m_track2 == null || m_track3 == null || m_track4 == null) {

			Debug.Log ("Tracks not found"); // logs error
		}
		
		// Checks for audio source
		if (m_audioSource != null) {

			// Checks for audio
			if (m_track1 != null) {

				m_audioSource.PlayOneShot (m_track4); // plays track
			}
		} else {

			Debug.Log ("Audio not found"); // Debug log
		}
	}
		
	// sets track that has been selected
	public void SetTrackPlaying(bool one, bool two, bool three, bool four){

		m_track1IsPlaying = one; // one
		m_track2IsPlaying = two; // two
		m_track3IsPlaying = three; // three
		m_track4IsPlaying = four; // four

		ChangeMusic (); // changes the track
	}

	// changes music
	void ChangeMusic ()
	{
		// if track selected
		if (m_track1IsPlaying) {

			m_track2IsPlaying = false; // set to false
			m_track3IsPlaying = false; // set to false
			m_track4IsPlaying = false; // set to false

			m_audioSource.Stop (); // stops current audio

			m_audioSource.PlayOneShot (m_track1); // play 

		}
		// if track selected
		if (m_track2IsPlaying) {

			m_track1IsPlaying = false; // set to false
			m_track3IsPlaying = false; // set to false
			m_track4IsPlaying = false; // set to false

			m_audioSource.Stop (); // stops current audio

			m_audioSource.PlayOneShot (m_track2); // play
		}
		// if track selected
		if (m_track3IsPlaying) {

			m_track2IsPlaying = false; // set to false
			m_track1IsPlaying = false; // set to false
			m_track4IsPlaying = false; // set to false

			m_audioSource.Stop (); // stops current audio

			m_audioSource.PlayOneShot (m_track3); // play
		}
		// if track selected
		if (m_track4IsPlaying) {

			m_track2IsPlaying = false; // set to false
			m_track3IsPlaying = false; // set to false
			m_track1IsPlaying = false; // set to false

			m_audioSource.Stop (); // stops current audio

			m_audioSource.PlayOneShot (m_track4); // play 	
		}
	}

	// Plays audio
	public void PlayAudio(AudioSource audiosource, AudioClip audioclip){

		audiosource.PlayOneShot (audioclip); // plays clip
	}
}