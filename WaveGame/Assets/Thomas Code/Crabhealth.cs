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
    public AudioSource mouth; 
	// Use this for initialization
	void Start () {
        dead = false;
		if(manager == null)
        {
            manager = GameObject.Find("Global Systems").GetComponent<Observer>();
        }
        if (stuff == null)
        {
            stuff = this.GetComponent<enemyMovement>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(manager == null)
        {
            manager = GameObject.Find("Global Systems").GetComponent<Observer>();
        }
               
	}

    bool dead;

    public void takeDamage(int damage)
    {
        if (dead == false)
        {
            health -= damage;
            if (health <= 0)
            {

                stuff.canMove = false;
                manager.AddScore(type);
                if (type == "Escaped")
                {
                    Destroy(this.gameObject);

                }
                else
                {

                    mouth.Stop();
                    mouth.clip = manager.returnDeath(type); 
                    mouth.Play();
                    mouth.loop = false;
                    StartCoroutine("waitForCry");
                   
                }
                dead = true;

            }
        }
    }

    IEnumerator waitForCry()
    {
        print("in here");
        yield return new WaitForSeconds(mouth.clip.length);
        Destroy(this.gameObject);

    }

    void SpawnWord()
    {
        GameObject word = manager.returnWord();
        Instantiate(word, this.transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision)
    {
    
        if(collision.gameObject.tag == "AttackMop")
        {
            takeDamage(100);
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
                this.gameObject.tag = "Bad Guy";
            }
        }
    }
}
