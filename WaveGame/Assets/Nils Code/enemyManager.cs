using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour {

	public GameObject enemy;
	private int totalSpawns = 20;
	private float frequency = 1;
	public bool playing = true;
	private int wave = 1;

	public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
		StartCoroutine (spawn (wave));
	}
	
	// Update is called once per frame
	IEnumerator spawn(int wave) {

		switch(wave)
		{
		case 1:
			for (int i = 0; i < totalSpawns; i++) {
				int location = Random.Range (0, 5);
				Instantiate (enemy, spawnPoints[location].position, Quaternion.identity);				
				yield return new WaitForSeconds (frequency);
			}
			yield return "done";
			break;
		default:
			Instantiate (enemy, new Vector3 (0, 1, 48), Quaternion.identity);	
			yield return "done";
			break;
		}

	}
}
