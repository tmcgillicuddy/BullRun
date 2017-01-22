using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose_Screen_Options : MonoBehaviour {
    public Canvas score, loseMessage;

	// Use this for initialization
	void Start () {
        loseMessage.enabled = false;
        score.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ViewScore()
    {
        score.enabled = true;
        loseMessage.enabled = false; ;
        score.GetComponent<Canvas>().renderMode = 
    }
}
