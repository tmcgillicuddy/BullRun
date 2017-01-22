using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour {

    public enemyManager spawnSystem;
    public KillTracker scoreBoard;
    public playerController thisPlayer;
    public GameObject[] words;
    public Camera LoseCamera;


    public int baseScore, totalScore, waveEnemies, baseMoney;
    public int Red, Blue, Gold, Green, Rainbow;
    public int Gentleman;

	// Use this for initialization
	void Start () {
        LoseCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        CheckEscape();
	}
    public int wordsAssigned;
  public GameObject returnWord()
    {
        GameObject temp;
        switch(wordsAssigned%3)
        {
            case 0:
                temp = words[0];
                break;
            case 2:
                temp = words[1];
                break;

            default:
                temp = words[2];
                    break;


        }
        wordsAssigned++;
        return temp;

    }

    void CheckEscape()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void setEnemies(int num)
    {
        waveEnemies = num;
    }

    public void LoseScreen()
    {
        thisPlayer.canMove = false;
        spawnSystem.FreezeAllUnits();
        for (int i = 0; i < 3; i++)
        {
          //  thisPlayer.thisUI.turretStatus[i].isFrozen = true;
        }

        thisPlayer.mainCamera.enabled = false;
        LoseCamera.enabled = true;

        LoseCamera.GetComponent<Lose_Screen_Options>().loseMessage.enabled = true;

        Destroy(thisPlayer.gameObject);

    }

    public void AddScore(string type)
    {
        if(type == "Red")
        {
            totalScore += baseScore * 1;
            thisPlayer.money += baseMoney * 1;
            Red++;
        }
        else if (type == "Blue")
        {
            totalScore += baseScore * 2;
            thisPlayer.money += baseMoney * 2;
            Blue++;
        }
        else if (type == "Green")
        {
            totalScore += (int)(baseScore * 1.5f);
            thisPlayer.money += (int)(baseMoney * 1.5f);
            Green++;
        }
        else if (type == "Gold")
        {
            totalScore += baseScore * 3;
            thisPlayer.money += baseMoney * 3;
            Gold++;
        }
        else if (type == "Rainbow")
        {
            totalScore += baseScore * 10;
            thisPlayer.money += baseMoney * 10;
            Rainbow++;
        }
        else if(type == "Escaped")
        {
            print("Hit the wall");
        }
        else
        {
            print("Something else took damage");
        }
        waveEnemies--;
      

        if(waveEnemies == 0)
        {
            print("No more bad guys");
            spawnSystem.NextWaveSetup();
        }

        thisPlayer.thisUI.UpdateScore();
        thisPlayer.thisUI.UpdateMoney();
        scoreBoard.UpdateKills();
    }

    public void DeathTracker(string attachtment)
    {
        if(attachtment == "Gentleman")
        {
            Gentleman++;
        }

        scoreBoard.UpdateKills();
    }
}
