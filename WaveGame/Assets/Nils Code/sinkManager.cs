using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinkManager : MonoBehaviour {
    public Observer god;

	public sinkCluster[] clusters;
	public int lives;

	// Use this for initialization
	void Start () {
        lives = 0;
        for (int i = 0; i < 4; i++)
        {
            lives += clusters[i].health;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateHealth()
	{
        lives = 0;
        for (int i = 0; i < clusters.Length; i++)
        {
            if (clusters[i] != null)
            {
                lives += clusters[i].health;
            }
        }
       // god.thisPlayer.thisUI.SendMessage("Sinks Are Under Attack");

        if (lives <= 0)
        {
            god.LoseScreen();
        }
	}
}
