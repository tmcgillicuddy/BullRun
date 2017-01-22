using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinkManager : MonoBehaviour {

	public sinkCluster cluster1, cluster2, cluster3, cluster4;
	public int lives;

	// Use this for initialization
	void Start () {
		updateHealth ();
	}
	
	// Update is called once per frame
	void Update () {
		updateHealth ();
	}

	void updateHealth()
	{
		lives = cluster1.health + cluster2.health + cluster3.health + cluster4.health;
	}
}
