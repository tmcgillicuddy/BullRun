using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

	public float xSpeed, ySpeed, zSpeed;
	public Transform target;

    public bool canMove;
	// Use this for initialization
	void Start () {
     //   canMove = true;
		if (target == null)
		{
			target = GameObject.FindGameObjectWithTag ("Player").transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (canMove == true)
        {
            float xTranslation = Time.deltaTime * xSpeed;
            transform.Translate(xTranslation, 0, 0, Space.World);
            float yTranslation = Time.deltaTime * ySpeed;
            transform.Translate(0, yTranslation, 0, Space.World);
            float zTranslation = Time.deltaTime * zSpeed;
            transform.Translate(0, 0, zTranslation, Space.World);
        }

		if (target != null) 
		{
			transform.LookAt(target);
			transform.Rotate (0, 90, 90);
		}
	}
}
