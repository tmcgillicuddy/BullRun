using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordLife : MonoBehaviour {
    public float life = 1f;

    public Transform player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }


        transform.LookAt(player);
        transform.Rotate(0, 180, 0);
        life -= Time.deltaTime;
        this.transform.Translate(new Vector3(0,1*Time.deltaTime,0));
        if(life<=0)
        {
            Destroy(this.gameObject);
        }
	}
}
