using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// enemy count
public class EnemyCount : MonoBehaviour {

	public Text m_enemyObjectiveText; // enemy objective text
	public Text m_newObjectiveText; // new objective text
	public Text m_enemyCounterText; // enemy counter text
	public Text m_getToTheChopperText; // get to chopper text

	public int m_enemiesRemaining; // enemies remaining

	// Use this for initialization
	void Start () {

		m_newObjectiveText.enabled = false; // new objective not set
		m_getToTheChopperText.enabled = false; // get to chopper not set

		m_enemiesRemaining = 6; // enemies remaining
	}
	
	// Update is called once per frame
	void Update () {

		// enemy counter converted to text
		m_enemyCounterText.GetComponent<Text> ().text = m_enemiesRemaining.ToString ();

		// when enemy count is 0
		if (m_enemiesRemaining == 0) {

			DisplayNextObjective (); // display new objective
		}
	}

	// display new objective
	void DisplayNextObjective(){

		m_newObjectiveText.enabled = true; // new objective enabled
		m_enemyObjectiveText.enabled = false; // enemy objective not disabled
		m_enemyCounterText.enabled = false; // counter now disabled

		m_getToTheChopperText.enabled = true; // get to chopper text enabled
	}
}