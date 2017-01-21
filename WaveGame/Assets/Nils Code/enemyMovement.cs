using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

	public float xSpeed, ySpeed, zSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float xTranslation = Time.deltaTime * xSpeed;
		transform.Translate (xTranslation, 0, 0, Space.World);
		float yTranslation = Time.deltaTime * ySpeed;
		transform.Translate (0, yTranslation, 0, Space.World);
		float zTranslation = Time.deltaTime * zSpeed;
		transform.Translate (0, 0, zTranslation, Space.World);
	}
}
