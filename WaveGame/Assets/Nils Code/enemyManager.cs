using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour {

	public GameObject red, blue, gold, green, rainbow;
    public int totalSpawn, spawned;
	private float frequency = 1;
    public bool downTime, spawning;
	private int wave = 0;
    public List<Transform> spawnPoints;

    public Observer god;

	// Use this for initialization
	void Start () {
        NextWaveSetup();
	}


    private void Update()
    {
        CountDown();
        SpawnWave();
    }

    public float timer;
    void CountDown()
    {
        if(downTime == true)
        {
            timer -= Time.deltaTime;

            if(timer <=0)
            {
                spawning = true;
                downTime = false;
                god.waveEnemies += totalSpawn;
            }
        }

    }

    public void NextWaveSetup()
    {
        downTime = true;
        wave++;
        timer = 2f;
    }

    void SpawnWave()
    {
        if (spawning == true)
        {
            if(spawned < totalSpawn)
            {
                if (wave == 1)
                {
                    for (int i = 0; i < spawnPoints.Count; i++)
                    {
                        Instantiate(red, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity);
                        spawned++;
                    }
                }
                else if (wave == 2)
                {
                    for (int i = 0; i < spawnPoints.Count; i++)
                    {
                        if (spawned % 5 == 0)
                        {
                            Instantiate(blue, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity);
                        }
                        else
                        {
                            Instantiate(red, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity);
                        }
                        spawned++;
                    }
                }
                else if (wave == 3)
                {
                    for (int i = 0; i < spawnPoints.Count; i++)
                    {
                        if (spawned % 10 == 0)
                        {
                            Instantiate(gold, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity);
                        }
                        else if (spawned % 5 == 0)
                        {
                            Instantiate(blue, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity);
                        }
                        else
                        {
                            Instantiate(red, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity);

                            spawned++;
                        }
                    }
                }
                else if (wave == 4)
                {
                    for (int i = 0; i < spawnPoints.Count; i++)
                    {

                        if (spawned % 25 == 0)
                        {
                            Instantiate(green, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity);
                        }
                        else if (spawned % 10 == 0)
                        {
                            Instantiate(gold, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity);
                        }
                        else if (spawned % 5 == 0)
                        {
                            Instantiate(blue, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity);
                        }
                        else
                        {
                            Instantiate(red, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity);
                        }

                        spawned++;
                    }
                }
                else if (wave == 5)
                {
                    for (int i = 0; i < spawnPoints.Count; i++)
                    {
                        spawned++;
                        if (spawned % 100 == 0)
                        {
                            Instantiate(rainbow, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity);
                        }
                        else if (spawned % 25 == 0)
                        {
                            Instantiate(green, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity);
                        }
                        else if (spawned % 10 == 0)
                        {
                            Instantiate(gold, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity);
                        }
                        else if (spawned % 5 == 0)
                        {
                            Instantiate(blue, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity);
                        }
                        else
                        {
                            Instantiate(red, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity);
                        }
                        
                    }
                }
            }
            else
            {
                spawning = false;
            }
        }
    }
}
