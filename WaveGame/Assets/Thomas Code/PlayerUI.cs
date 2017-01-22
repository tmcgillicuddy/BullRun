using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUI : MonoBehaviour {
    public enemyManager waveInfo;
    public Observer god;

    public Text countDownTimer, scoreCounter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTimer();

	}


    public void UpdateScore()
    {
        scoreCounter.text = "Score: " + god.totalScore.ToString();
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
