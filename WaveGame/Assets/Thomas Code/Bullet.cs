using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public int damage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bad Guy")
        {
            //print("Hit Crab");
            collision.gameObject.GetComponent<Crabhealth>().takeDamage(damage);
          
        }

        Destroy(this.gameObject);
    }
}
