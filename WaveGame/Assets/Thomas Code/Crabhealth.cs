using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crabhealth : MonoBehaviour {
    public int health;
    public Observer manager;
    public string type;
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
            print("Died");
            manager.AddScore(type);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Hit something");
        if(collision.gameObject.tag == "Mop")
        {
            print("Hit Mop");
            takeDamage(10);
        }
    }
}
