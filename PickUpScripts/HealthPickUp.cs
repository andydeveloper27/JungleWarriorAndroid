using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages health pick up
public class HealthPickUp : MonoBehaviour {

	public PlayerHealth playerhealth; // player health

	public bool m_pickUpEnabled; // pick up enabled

	// Use this for initialization
	void Start () {

		m_pickUpEnabled = false; // pick up is not enabled
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeScale == 1) {
			
			transform.Rotate (0f, 5f, 0f, Space.World); // rotates gameobject
		}
	}

	// upon colliding with player collider
	void OnTriggerEnter (Collider _collider)
	{
		// when player collides with gameobject
		if (_collider.gameObject.tag == "Player") {

			m_pickUpEnabled = true; // pick up enabled

			playerhealth.m_health = 100; // health set back to 100

			Destroy (gameObject); // destroy gameobject
		}
	}
}