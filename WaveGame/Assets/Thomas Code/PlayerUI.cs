using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUI : MonoBehaviour {
    public enemyManager waveInfo;
    public playerController thisPlayer;
    public Text countDownTimer, scoreCounter, waterText, alertText, moneyText;
    public Slider waterBar;

    public turretAI[] turretStatus;
    public Text[] turretLevels;
    public Slider[] turretAmmo;
	// Use this for initialization
	void Start () {

        UpdateSlider();
        alertText.enabled = false;
        UpdateScore();
        UpdateMoney();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateTimer();
        CheckAlert();
       // UpdateTurretStatus();
	}

    public void UpdateTurretStatus()
    {
        for(int i=0; i < 3; i++)
        {
            turretLevels[i].text = "Level: " + turretStatus[i].currentLevel.ToString();
            turretAmmo[i].maxValue = turretStatus[i].maxAmmo;
            turretAmmo[i].value = turretStatus[i].ammo;
        }
    }

   public float alertTimer, alertTime;
    public void CheckAlert()
    {
        if(alerting)
        {
           
            if(alertTimer <= 0)
            {
                alerting = false;
                alertText.enabled = false;
            }
            alertTimer -= Time.deltaTime;
        }
        
    }
    public void UpdateSlider()
    {
        waterText.text = "Water: " + thisPlayer.water + "/100";
        waterBar.value = thisPlayer.water;
    }

    public void UpdateScore()
    {
        scoreCounter.text = "Score: " + thisPlayer.god.totalScore.ToString();
    }

    void UpdateTimer()
    {
        if(waveInfo.downTime)
        {
            countDownTimer.enabled = true;
            countDownTimer.text = "Next Wave: " + waveInfo.timer.ToString("N0");
        }
        else
        {
            countDownTimer.enabled = false;
        }
    }

  
    public void UpdateMoney()
    {
        moneyText.text = "Money: $" + thisPlayer.money.ToString();
    }

    bool alerting;
    public void FlashMessage(string message)
    {
        alerting = true;
        alertText.text = message;
        alertText.enabled = true;
        alertTimer += alertTime;
    }
}
