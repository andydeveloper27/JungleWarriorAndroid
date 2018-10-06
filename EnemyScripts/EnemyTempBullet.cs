using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages enemy bullet
public class EnemyTempBullet : MonoBehaviour {
	
	public Transform m_player; // player

	private float m_speed = 50f; // speed of the bullet
	private float m_damage = 6f; // damage it has on the player's health

	// runs upon awake
	void Awake(){

		m_player = GameObject.FindWithTag ("Player").transform; // finds the transform with Player tag
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += transform.forward * Time.deltaTime * m_speed; // positiuon is put forward with set speed

		// when bullet is within this distance of the players transform position
		if (Vector3.Distance (transform.position, m_player.position) < 1) {

			m_player.GetComponent<PlayerHealth> ().m_health -= m_damage; // take set damage away

			Destroy (gameObject); // finally destroy bullet
		}
	}
}
