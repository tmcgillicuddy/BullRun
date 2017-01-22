using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour {
    public int baseScore, totalScore, waveEnemies;
    public enemyManager spawnSystem;
    public KillTracker scoreBoard;
    public PlayerUI thisPlayer;

    public int Red, Blue, Gold, Green, Rainbow;

    public int Gentleman;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckEscape();
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

    public void AddScore(string type)
    {
        if(type == "Red")
        {
            totalScore += baseScore * 1;
            Red++;
        }
        else if (type == "Blue")
        {
      
            totalScore += baseScore * 2;
            Blue++;
        }
        else if (type == "Green")
        {
            totalScore += (int)(baseScore * 1.5f);
            Green++;
        }
        else if (type == "Gold")
        {
            totalScore += baseScore * 3;
            Gold++;
        }
        else if (type == "Rainbow")
        {
            totalScore += baseScore * 10;
            Rainbow++;
        }

        waveEnemies--;
        scoreBoard.UpdateKills();

        if(waveEnemies == 0)
        {
            print("No more bad guys");
            spawnSystem.NextWaveSetup();
        }

        thisPlayer.UpdateScore();
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
