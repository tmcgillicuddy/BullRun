using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public int damage;
    public string type;
    int hitCounter;
	// Use this for initialization
	void Start () {
        hitCounter = 0;
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
        if (type != "Puck")
        {

            Destroy(this.gameObject);
        }
        else
        {
            hitCounter++;
            if(hitCounter ==3)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
