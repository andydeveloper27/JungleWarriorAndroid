using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enemy AI class to manage enemy movement and detection
public class EnemyAI : MonoBehaviour {

	public Transform m_player; // player

	public Transform[] m_target; // targets for the enemy to patrol
	public float m_speed; // speed in which the enemy runs

	public bool m_attackingPlayer; // set to whether the enemy is attacking the player or not

	private int m_currentPos; // current position

	private float m_playerDistance; // distance from player
	private float m_attackRange; // attack range

	private Animator m_animator; // animator

	// start
	void Start(){
		
		m_attackRange = 20.0f; // attack range
	
		m_animator = GetComponent<Animator> (); // animator

		m_attackingPlayer = false; // enemy is not attacking player

		// Checks if animator is available
		if (m_animator.GetComponent<Animator> () == null) {

			Debug.Log ("Enemy Animator not found");
		}

		// Checks for player
		if (m_player == null) {

			Debug.Log ("Player not found");
		}
	}

	// Update is called once per frame
	void FixedUpdate () {

		m_playerDistance = Vector3.Distance (m_player.position, transform.position); // distance between enemy to player

		// when not attacking the player
		if (!m_attackingPlayer) {

			m_animator.SetBool ("Shoot", false); // shooting animation set to false
			m_animator.SetBool ("Run", true); // run animation set to true

			// when enemy has not reached target position
			if (transform.position != m_target [m_currentPos].position) {

				// makes sure the enemy is rotated in the correct direction
				Vector3 relativePos = m_target [m_currentPos].position - transform.position; // relativePos position
				Quaternion rotation = Quaternion.LookRotation (relativePos); // Quaternion rotation
				transform.rotation = rotation; // rotation

				// position is enemy moving towards target position
				Vector3 pos = Vector3.MoveTowards (transform.position, m_target [m_currentPos].position, m_speed * Time.deltaTime);

				// rigibody
				if (GetComponent<Rigidbody> () != null) {
					
					GetComponent<Rigidbody> ().MovePosition (pos); // moves rigidbody
				}

			} else
				m_currentPos = (m_currentPos + 1) % m_target.Length; // current position is next target position
		}

		// when player's distance is less than or equal to attack range
		if (m_playerDistance <= m_attackRange) {

			m_attackingPlayer = true; // attacking player set to true

			// If attacking player
			if (m_attackingPlayer) {

				m_animator.SetBool ("Shoot", true); // shooting animation set to false
				m_animator.SetBool ("Run", false); // run animation set to false

				AttackPlayer (); // attack player
			}
		} 
		else {

			m_animator.SetBool ("Shoot", false); // shooting animation set to false
			m_animator.SetBool ("Run", true); // run animation set to true

			m_attackingPlayer = false; // player not being attacked
		}
	}

	// attack player
	private void AttackPlayer(){

		// makes sure the enemy is rotated in the correct direction
		Vector3 relativePos = m_player.position - transform.position; // relative position
		Quaternion rotation = Quaternion.LookRotation (relativePos); // Quaternion rotation
		transform.rotation = rotation; // rotation
	}
}