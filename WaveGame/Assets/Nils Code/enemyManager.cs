using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour {

	public GameObject enemy;
	public float totalSpawns;
	public float frequency;
	public float counter;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawn", 0, frequency);
	}
	
	// Update is called once per frame
	void spawn() {
		Instantiate (enemy);
	}
}
