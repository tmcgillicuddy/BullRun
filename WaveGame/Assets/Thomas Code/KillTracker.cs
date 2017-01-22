using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KillTracker : MonoBehaviour {
    public Observer god;

    public Text[] ColorNums;
    public Text[] TypeNums;
	// Use this for initialization
	void Start () {
        UpdateKills();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateKills()
    {
        ColorNums[0].text = god.Red.ToString();
        ColorNums[1].text = god.Blue.ToString();
        ColorNums[2].text = god.Gold.ToString();
        ColorNums[3].text = god.Green.ToString();
        ColorNums[4].text = god.Rainbow.ToString();

        TypeNums[0].text = god.Gentleman.ToString();
        TypeNums[1].text = god.Gentleman.ToString();
        TypeNums[2].text = god.Gentleman.ToString();
        TypeNums[3].text = god.Gentleman.ToString();

    }
}
