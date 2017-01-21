using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
		if (target == null)
		{
			target = GameObject.FindGameObjectWithTag ("Player").transform;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target != null) 
		{
			transform.LookAt (target);
		}

	}
}
