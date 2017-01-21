using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour {

	public GameObject enemy;
    private int totalSpawn, spawned;
	private float frequency = 1;
    public bool downTime, spawning;
	private int wave = 0;
    public List<Transform> spawnPoints;

	// Use this for initialization
	void Start () {
		
	}


    private void Update()
    {
        CountDown();
        SpawnWave();
    }

    float timer;
    void CountDown()
    {
        if(downTime == true)
        {
            timer -= Time.deltaTime;

            if(timer <=0)
            {
                spawning = true;
                downTime = false; 
            }
        }

    }


    void SpawnWave()
    {
        if (spawning == true)
        {
            if(spawned < totalSpawn)
            {

            }
            else
            {
                spawning = false;
            }
        }
    }
}
