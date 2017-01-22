using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinkCluster : MonoBehaviour {

	public GameObject sink1, sink2, sink3, sink4;
	int life = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		//print("Hit something");
		if(collision.gameObject.tag == "Mop")
		{
			takeDamage(10);
		}
	}
}
