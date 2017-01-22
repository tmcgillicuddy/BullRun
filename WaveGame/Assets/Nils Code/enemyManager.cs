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
    public Transform spawnParent;

    public Observer god;

	// Use this for initialization
	void Start () {
        NextWaveSetup();
	}


    private void Update()
    {
        CountDown();
        SpawnWave();
        if(Input.GetKeyDown(KeyCode.H))
        {
            KillUnits();
        }
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
        totalSpawn += 150;
        spawned = 0;
        timer = 2f;
    }



    void KillUnits()
    {
        foreach(Transform child in spawnParent)
        {
            child.GetComponent<Crabhealth>().takeDamage(child.GetComponent<Crabhealth>().health);
        }
    }

    int inGame;
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
                      GameObject temp=  Instantiate(red, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                        temp.transform.parent = spawnParent;
                        spawned++;
                    }
                }
                else if (wave == 2)
                {
                    for (int i = 0; i < spawnPoints.Count; i++)
                    {
                        if (spawned % 5 == 0)
                        {
                            GameObject temp = Instantiate(blue, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                            temp.transform.parent = spawnParent;
                        }
                        else
                        {
                            GameObject temp = Instantiate(red, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                            temp.transform.parent = spawnParent;
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
                            GameObject temp = Instantiate(gold, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                            temp.transform.parent = spawnParent;
                        }
                        else if (spawned % 5 == 0)
                        {
                            GameObject temp = Instantiate(blue, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                            temp.transform.parent = spawnParent;
                        }
                        else
                        {
                            GameObject temp = Instantiate(red, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                            temp.transform.parent = spawnParent;
                           
                        }
                        spawned++;
                    }
                }
                else if (wave == 4)
                {
                    for (int i = 0; i < spawnPoints.Count; i++)
                    {

                        if (spawned % 25 == 0)
                        {
                            GameObject temp = Instantiate(green, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                            temp.transform.parent = spawnParent;
                        }
                        else if (spawned % 10 == 0)
                        {
                            GameObject temp = Instantiate(gold, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                            temp.transform.parent = spawnParent;
                        }
                        else if (spawned % 5 == 0)
                        {
                            GameObject temp = Instantiate(blue, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                            temp.transform.parent = spawnParent;
                        }
                        else
                        {
                            GameObject temp = Instantiate(red, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                            temp.transform.parent = spawnParent;
                        }

                        spawned++;
                    }
                }
                else if (wave == 5)
                {
                    for (int i = 0; i < spawnPoints.Count; i++)
                    {
                       // spawned++;
                        if (spawned % 100 == 0)
                        {
                            print("Spawned Rainbow");
                            GameObject temp = Instantiate(rainbow, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                            temp.transform.parent = spawnParent;
                        }
                        else if (spawned % 25 == 0)
                        {
                            GameObject temp = Instantiate(green, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                            temp.transform.parent = spawnParent;
                        }
                        else if (spawned % 10 == 0)
                        {
                            GameObject temp = Instantiate(gold, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                            temp.transform.parent = spawnParent;
                        }
                        else if (spawned % 5 == 0)
                        {
                            GameObject temp = Instantiate(blue, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                            temp.transform.parent = spawnParent;
                        }
                        else
                        {
                            GameObject temp = Instantiate(red, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                            temp.transform.parent = spawnParent;
                        }
                        spawned++;

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
