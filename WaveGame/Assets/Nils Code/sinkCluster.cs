using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sinkCluster : MonoBehaviour {
    public sinkManager manager;

	public GameObject[] sinks;
	public bool alive = true;
	public int health = 4;


	// Use this for initialization
	void Start () {
		if(manager == null)
        {
            manager = GameObject.Find("Sink Manager").GetComponent<sinkManager>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionStay(Collision collision)
	{
		//print("Hit something");
		if(collision.gameObject.tag == "Bad Guy")
		{
            if (health > 0)
            {
                Destroy(sinks[health - 1]);
                health--;


                manager.updateHealth();
            }
		}
	}
}
