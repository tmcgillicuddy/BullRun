using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenHeliAI : MonoBehaviour {
    public Transform target;
    public bool goingToTarget, dropping, retreat;
    public GameObject baddie;

    public enemyManager boss;
    public float speed;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Moving();
        Spawn();
        Retreat();
	}
    public int spawned, max;
    public float spawnTimer, timer;
    void Spawn()
    {
        if (dropping == true)
        {
            if (timer <= 0 && spawned < max)
            {
                timer += spawnTimer;
                GameObject temp = Instantiate(baddie, this.transform.position+ new Vector3(Random.Range(-1.0f, 1.0f), 0, spawned), Quaternion.identity) as GameObject;
               
                temp.GetComponent<Rigidbody>().useGravity = true;
                temp.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY;
                temp.GetComponent<enemyMovement>().canMove = false;
                temp.GetComponent<Rigidbody>().AddForce(Vector3.up*4, ForceMode.Force);
                temp.tag = "Untagged";
                temp.transform.parent = boss.spawnParent;
                spawned++;

                if(spawned == max)
                {
                    dropping = false;
                    retreat = true;
                }
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    void Retreat()
    {
        if(retreat)
        {
            this.transform.Translate(new Vector3(0,1* speed,0));

            if(this.transform.position.y >= 10f)
            {
                Destroy(this.gameObject);
            }
        }
    }
    void Moving()
    {
        if(goingToTarget)
        {
            this.transform.LookAt(target);
            this.transform.Translate(new Vector3(0,0,1*speed));
        }

        if(Vector3.Distance(this.transform.position, target.position) < 1)
        {
            goingToTarget = false;
            dropping = true;
        }
    }
}
