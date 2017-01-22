using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crabhealth : MonoBehaviour {
    public int health;
    public Observer manager;
    public string type;
    public string attachment;
    public enemyMovement stuff;
   public  GameObject paraChute;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(manager == null)
        {
            manager = GameObject.Find("Global Systems").GetComponent<Observer>();
        }
               
	}

    public void takeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            manager.AddScore(type);
            Destroy(this.gameObject);
           
        }
    }

    void SpawnWord()
    {
        GameObject word = manager.returnWord();
        Instantiate(word, this.transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print("Hit something");
        if(collision.gameObject.tag == "AttackMop")
        {
            takeDamage(10);
            int test = Random.Range(1, 100);
            if (test > 80)
            {
                SpawnWord();
            }
        }

        if(collision.gameObject.tag == "Back Wall")
        {
            type = "Escaped";
            takeDamage(health);
        }

        if(collision.gameObject.tag == "Ground")
        {
            if (type == "Green")
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                stuff.canMove = true;
                Destroy(paraChute);
            }
        }
    }
}
