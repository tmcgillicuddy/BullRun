using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveWater : MonoBehaviour {
    public bool playerPresent;
    public int currentFill;
    public playerController thisPlayer;
    public float divider;
    public Canvas UIStuff;
    public Text fillAmount;

	// Use this for initialization
	void Start () {
		if(thisPlayer == null)
        {
            thisPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        }
        currentFill = 50;
        UIStuff.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        CheckforRefill();
        Fill();
	}

    float timer;
    public void Fill()
    {
        if (currentFill < 50)
        {
            if (timer <= 0)
            {
                currentFill += 1;
                timer = .8f;
            }
            timer -= Time.deltaTime;
        }
        fillAmount.text = "Fill: " + currentFill;
    }

    public void CheckforRefill()
    {
        if(playerPresent)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                if (thisPlayer.water < 100)
                {
                    if (currentFill + thisPlayer.water > 100)
                    {
                        thisPlayer.water = 100;
                        currentFill -= 100 - thisPlayer.water;
                        currentFill = 0;
                    }
                    else
                    {
                      
                        thisPlayer.water += currentFill;
                        currentFill = 0;
                    }
                }
                else
                {
                   
                    thisPlayer.thisUI.FlashMessage("Bucket is Full");
                }
               

                thisPlayer.thisUI.UpdateSlider();
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerPresent = true;
            UIStuff.enabled = true;
         }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerPresent = false;

            UIStuff.enabled = false;
        }
    }
}
