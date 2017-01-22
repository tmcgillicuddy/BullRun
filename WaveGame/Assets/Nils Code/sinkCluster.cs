using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinkCluster : MonoBehaviour {

	public GameObject sink1, sink2, sink3, sink4;
	public bool alive = true;
	public int health = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionStay(Collision collision)
	{
		//print("Hit something");
		if(collision.gameObject.tag == "Bad Guy")
		{
			if (health == 4)
			{
				Destroy (sink1);
				Destroy (collision.gameObject);
				health--;
			} 
			else if (health == 3) 
			{
				Destroy (sink4);
				Destroy (collision.gameObject);
				health--;
			}
			else if (health == 2) 
			{
				Destroy (sink2);
				Destroy (collision.gameObject);
				health--;
			}
			else if (health == 1) 
			{
				Destroy (sink3);
				Destroy (collision.gameObject);
				health--;
				alive = false;
			}
		}
	}
}
