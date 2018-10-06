using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ammo pick up class
public class AmmoPickUp : MonoBehaviour {

	public PlayerShooting playerShooting; // player shooting

	public GameObject m_ammoPickUp; // ammo pick up

	public bool m_pickUpEnabled; // pick up enabled bool

	// Use this for initialization
	void Start () {

		m_pickUpEnabled = false; // pick up is not enabled
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeScale == 1) {
			
			m_ammoPickUp.transform.Rotate (0f, 5f, 0f, Space.World); // rotates gameobject
		}
	}

	// upon colliding with collider
	void OnTriggerEnter(Collider _collider){

		// when player collides with gameobject
		if (_collider.gameObject.tag == "Player") {

			m_pickUpEnabled = true;// pick up enabled

			playerShooting.m_bulletsRemaining = 30; // bullets increased

			Destroy (m_ammoPickUp); // destroy gameobject
		}
	}
}
