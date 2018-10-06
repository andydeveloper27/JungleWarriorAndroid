using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages weapon sway and gives it a little realism effect when moving about
public class WeaponSway : MonoBehaviour {

	public Vector3 m_offSet; // offset
	private Vector3 m_initialPosition; // oinitial position

	public float m_swayAmount; // sway amount
	public float m_smoothAmount; // smoothness amount

	void Start(){

		m_initialPosition = transform.localPosition; // local position
	}

	// Update is called once per frame
	void Update () {

		if (Time.timeScale != 0) {
			
			float movementX = -Input.GetAxis ("Mouse X") * m_swayAmount; // x movement
			float movementY = -Input.GetAxis ("Mouse Y") * m_swayAmount; // y movement

			Vector3 finalPosition = new Vector3 (movementX, movementY, 0); // final position decided upon x and y axis movements

			// local position set upon transforms local position altering
			transform.localPosition = Vector3.Lerp (transform.localPosition, finalPosition + m_initialPosition,
				Time.deltaTime * m_smoothAmount);
		}
	}
}