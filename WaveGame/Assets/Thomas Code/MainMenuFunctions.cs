using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour {
    string levelToLoad;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadMainLevel(string level)
    {
        levelToLoad = level;
        StartCoroutine(LoadNewLevel());
    }
    IEnumerator LoadNewLevel()
    {
        if (levelToLoad == "MainLevel")
        {
            yield return new WaitForSeconds(2f);
            AsyncOperation async = SceneManager.LoadSceneAsync(levelToLoad);
            while (!async.isDone)
            {
                yield return null;
            }
        }
        else
        {
            SceneManager.LoadScene(levelToLoad);

        }
    }
}
