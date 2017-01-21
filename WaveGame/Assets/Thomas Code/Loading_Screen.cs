using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading_Screen : MonoBehaviour {
   public  MainMenuFunctions Info;

	// Use this for initialization
	void Start () {
		
	}

	void Awake()
    {
        // this.GetComponenet<MainMenuFunctions>().LoadMainLevel("MainLevel");
        Info.LoadMainLevel("MainLevel");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
