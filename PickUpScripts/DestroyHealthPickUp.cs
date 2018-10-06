using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages when to play particle effect
public class DestroyHealthPickUp : MonoBehaviour {

	public HealthPickUp healthPickUp; // health pick up

	public ParticleSystem m_particleSystem; // particle system

	// Use this for initialization
	void Start () {

		m_particleSystem.Stop (); // makes sure particle system is not playing upon starting
	}
	
	// Update is called once per frame
	void Update () {

		// if health has been enabled
		if (healthPickUp.m_pickUpEnabled) {

			if (m_particleSystem != null) {

				StartCoroutine (ParticleSystem ()); // Start ParticleSystem()
			}
		}
	}

	// manages particle system
	IEnumerator ParticleSystem(){

		m_particleSystem.Play (); // play particle system

		yield return new WaitForSeconds (2.0f); // waits for two seconds

		Destroy (m_particleSystem); // destroys particle system
	}
}
