using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManger : MonoBehaviour {
    public Canvas Main, Credits;
    public GameObject wall;

	// Use this for initialization
	void Start () {
        returnToMain();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenCredits()
    {
        print("Going to Credits");
        Credits.enabled = true;
        Main.enabled = false;
        wall.transform.position = new Vector3(0, 0, 19);
    }

    public void returnToMain()
    {
        print("Doing Shit");
        Main.enabled = true;
        Credits.enabled = false;
        wall.transform.position = new Vector3(0, -100, 19);
    }

}
