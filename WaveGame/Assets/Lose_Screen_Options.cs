using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Lose_Screen_Options : MonoBehaviour {
    public Canvas score, loseMessage;

    CursorLockMode wantedMode = CursorLockMode.Confined;
    public Button viewScoreButton;
    public Button[] finalButtons;
    // Use this for initialization
    void Start () {
        loseMessage.enabled = false;
        score.enabled = false;
        viewScoreButton.enabled = false;
        for (int i = 0; i < 3; i++)
        {
            finalButtons[i].enabled = false;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ViewScore()
    {
        score.enabled = true;
        loseMessage.enabled = false; ;
        Cursor.visible = true;
        Cursor.lockState = wantedMode;
        viewScoreButton.enabled = false;
        for(int i =0; i < 3; i ++)
        {
            finalButtons[i].enabled = true;
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync("MainLevel");
    }

    public void ReturnToMenu()
    {
        StartCoroutine(LoadNewLevel());
    }

    IEnumerator LoadNewLevel()
    {
       yield return new WaitForSeconds(2f);
       AsyncOperation async = SceneManager.LoadSceneAsync("Main Menu");
       while (!async.isDone)
       {
           yield return null;
       }

    }


    public void QuitGame()
    {
        Application.Quit();

    }

}
