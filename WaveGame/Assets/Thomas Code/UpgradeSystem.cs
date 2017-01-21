using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour {
    public bool playerPresent;
    public turretAI thisTurret;
    public Canvas UpgradeScreen;
    public Text priceText, titleText;
    public playerController thisplayer;
    public Image Panel;


    public int level, cost;
	// Use this for initialization
	void Start () {
        UpgradeScreen.enabled = false;
        UpdatePrice();
        if (thisplayer == null)
        {
            thisplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        }
    }
	
	// Update is called once per frame
	void Update () {
      //  UpdatePrice();
        CheckPurchase();
	}


    void CheckPurchase()
    {
        if(playerPresent)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(thisplayer.money >= cost)
                {
                    Upgrade();
                }
                else
                {
                    StartCoroutine("NoMoney");
                   // UpdatePrice();
                }
            }

            if(Input.GetKeyDown(KeyCode.R))
            {
                if(thisplayer.water > 0)
                {
                    if(thisplayer.water > thisTurret.maxAmmo - thisTurret.ammo)
                    {
                        thisTurret.ammo = thisTurret.maxAmmo;
                        thisplayer.water -= thisTurret.maxAmmo - thisTurret.ammo;
                    }
                    else
                    {
                        thisplayer.water = 0;
                        thisTurret.ammo += thisplayer.water;
                    }
                }
            }
        }
    }

    IEnumerator NoMoney()
    {
        float timer = 2.0f;
        while (timer > 0)
        {
            print("Blah");
            priceText.text = "Not enough money";
            titleText.text = "";
            timer -= 0.1f;
        }
       
        yield return null;
        //UpdatePrice();
    }

        void Upgrade()
    {
        print("Upgrading");
        thisplayer.money -= cost;
        level++;
        cost *= 2;
        UpdatePrice();
    }
    void UpdatePrice()
    {
        print("UpdatePrice");
        titleText.text = "Turret Level " + level;
        priceText.text = "Upgrade: $" + cost;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            UpdatePrice();
            //     StopCoroutine("FadeOut");
            playerPresent = true;
            UpgradeScreen.enabled = true;
          //  StartCoroutine("FadeIn");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
           // StopCoroutine("FadeIn");
            playerPresent = false;
            UpgradeScreen.enabled = false;
           // StartCoroutine("FadeOut");
        }
    }
}
