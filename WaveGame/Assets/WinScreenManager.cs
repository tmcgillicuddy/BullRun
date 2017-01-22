using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
    public Canvas score, winMessage;

    CursorLockMode wantedMode = CursorLockMode.Confined;
    public Button viewScoreButton;
    public Button[] finalButtons;

    void Start()
    {
        winMessage.enabled = false;
        score.enabled = false;
        viewScoreButton.enabled = false;
        for (int i = 0; i < 3; i++)
        {
            finalButtons[i].enabled = false;
        }

    }

    public void ViewScore()
    {
        score.enabled = true;
        winMessage.enabled = false; ;
        Cursor.visible = true;
        Cursor.lockState = wantedMode;
        viewScoreButton.enabled = false;
        for (int i = 0; i < 3; i++)
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
