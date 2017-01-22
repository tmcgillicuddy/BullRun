using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{

    public GameObject red, blue, gold, green, rainbow;
    public int totalSpawn, spawned;
    public bool downTime, spawning;
    public int wave = 0;
    public List<Transform> spawnPoints;
    public Transform spawnParent;

    public Transform[] heliSpawns;
    public Observer god;

    public float waveDownTime;
    // Use this for initialization
    void Start()
    {
        NextWaveSetup();
    }


    private void Update()
    {
        CountDown();
        SpawnWave();
        if (Input.GetKeyDown(KeyCode.H))
        {
            KillUnits();
        }
    }

    public void FreezeAllUnits()
    {
        foreach (Transform child in spawnParent)
        {
            child.GetComponent<enemyMovement>().canMove = false;
        }
    }

    public float timer;
    void CountDown()
    {
        if (downTime == true)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                spawning = true;
                downTime = false;
                god.waveEnemies = totalSpawn;
            }
        }

    }

    public void NextWaveSetup()
    {
        downTime = true;
        wave++;
        //totalSpawn = 150;
        spawned = 0;
        timer = waveDownTime;
    }



    void KillUnits()
    {
       // SpawnHeli();
        
        foreach(Transform child in spawnParent)
        {
            child.GetComponent<Crabhealth>().takeDamage(child.GetComponent<Crabhealth>().health);
        }
        
    }

    void SpawnWave()
    {
        if (spawning == true)
        {
            if (spawned < totalSpawn)
            {
                if (wave == 1)
                {
                    for (int i = 0; i < spawnPoints.Count; i++)
                    {
                        if (spawned < totalSpawn)
                        {
                            GameObject temp = Instantiate(red, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                            temp.transform.parent = spawnParent;
                            spawned++;
                        }
                        else
                        {
                            break;
                        }
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
                            SpawnHeli();
                            spawned += 4;
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
                        spawned++;
                        if (spawned % 100 == 0)
                        {
                            GameObject temp = Instantiate(rainbow, spawnPoints[i].position + new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(0.0f, 25.0f)), Quaternion.identity) as GameObject;
                            temp.transform.parent = spawnParent;
                        }
                        else if (spawned % 25 == 0)
                        {
                            SpawnHeli();
                            spawned += 4;
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



    public Transform[] heliTargets;
    void SpawnHeli()
    {
        int x = Random.Range(0, 3);
        GameObject temp = Instantiate(green, heliSpawns[x].position, Quaternion.identity) as GameObject;
        temp.GetComponent<GreenHeliAI>().target = heliTargets[x];
        temp.GetComponent<GreenHeliAI>().boss = this;
    }
}
