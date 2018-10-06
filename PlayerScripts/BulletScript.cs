using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// collider detection
	void OnTriggerEnter(Collider collider){

		// if collider hits an enemy
		if (collider.gameObject.tag == "Enemy") {

			// takes damage off enemy health
			collider.gameObject.GetComponent<EnemyHealth> ().TakeDamage (20.0f);

			Destroy (this.gameObject);
		}

		if (collider.gameObject.tag == "Environment") {

			Destroy (this.gameObject);
		}
	}
}