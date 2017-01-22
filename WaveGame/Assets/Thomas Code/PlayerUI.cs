using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUI : MonoBehaviour {
    public enemyManager waveInfo;

    public Text countDownTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTimer();
	}

    void UpdateTimer()
    {
        if(waveInfo.downTime)
        {
            countDownTimer.enabled = true;
            countDownTimer.text = waveInfo.timer.ToString();
        }
        else
        {
            countDownTimer.enabled = false;
        }
    }
}
