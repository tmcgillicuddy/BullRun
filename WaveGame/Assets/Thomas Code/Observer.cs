using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{

    public enemyManager spawnSystem;
    public KillTracker scoreBoard;
    public playerController thisPlayer;
    public GameObject[] words;
    public Camera LoseCamera;
    public AudioClip[] deaths;

    public int wave;
    public int baseScore, totalScore, waveEnemies, baseMoney;
    public int Red, Blue, Gold, Green, Rainbow, Escaped;
    public int Gentleman;

    // Use this for initialization
    void Start()
    {
        LoseCamera.enabled = false;

        winCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckEscape();
    }

    public int wordsAssigned;
    public GameObject returnWord()
    {
        GameObject temp;
        switch (wordsAssigned % 3)
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
        if (Input.GetKey(KeyCode.Escape))
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
              thisPlayer.thisUI.turretStatus[i].isFrozen = true;
        }

        thisPlayer.mainCamera.enabled = false;
        LoseCamera.enabled = true;

        LoseCamera.GetComponent<Lose_Screen_Options>().loseMessage.enabled = true;
        LoseCamera.GetComponent<Lose_Screen_Options>().score.GetComponent<KillTracker>().UpdateKills();
        Destroy(thisPlayer.gameObject);
     
    }

    public void AddScore(string type)
    {
        if (thisPlayer != null)
        {
            if (type == "Red")
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
            else if (type == "Escaped")
            {
                Escaped++;
            }
            else
            {

            }
            waveEnemies--;


            if (waveEnemies == 0)
            {
                if (wave != 5)
                {
                    spawnSystem.NextWaveSetup();
                }
                else
                {
                    WinState();
                }
            }


            thisPlayer.thisUI.UpdateScore();
            thisPlayer.thisUI.UpdateMoney();
        }

        scoreBoard.UpdateKills();
    }

    public Camera winCam;
    public void WinState()
    {
        
        thisPlayer.canMove = false;
        spawnSystem.FreezeAllUnits();
        for (int i = 0; i < 3; i++)
        {
            print(i);
            thisPlayer.thisUI.turretStatus[i].isFrozen = true;
        }

        thisPlayer.mainCamera.enabled = false;
        winCam.enabled = true;

        winCam.GetComponent<WinScreenManager>().winMessage.enabled = true;
        winCam.GetComponent<WinScreenManager>().score.GetComponent<KillTracker>().UpdateKills();
        winCam.GetComponent<WinScreenManager>().viewScoreButton.enabled = true;

        Destroy(thisPlayer.gameObject);
    }

    public AudioClip returnDeath(string type)
    {
       
        if (thisPlayer != null)
        {
            AudioClip temp = null;
            if (type == "Red")
            {
              
                temp = deaths[0];
            }
            else if (type == "Blue")
            {
                temp = deaths[1];
            }
            else if (type == "Green")
            {
                temp = deaths[2];
            }
            else if (type == "Gold")
            {
                temp = deaths[3];
            }
            else if (type == "Rainbow")
            {
                temp = deaths[4];
            }
            else if (type == "Escaped")
            {
            
            }
            else
            {
        
            }
          
            return temp;
        }
        else
        {
            return null;
        }
       
    }
    public void DeathTracker(string attachtment)
    {
        if (attachtment == "Gentleman")
        {
            Gentleman++;
        }

        scoreBoard.UpdateKills();
    }
}
