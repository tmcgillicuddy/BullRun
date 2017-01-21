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
    }
	
	// Update is called once per frame
	void Update () {
        UpdatePrice();
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

                }
            }
        }
    }
    float f;
    IEnumerator FadeIn()
    {
        priceText.enabled = false;
        titleText.enabled = false;
        while (f <= 1f)
        {
            Color c = Panel.material.color;
            c.a = f;
            Panel.material.color = c;
            priceText.enabled = true;
            titleText.enabled = true;
            f += 0.1f;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        priceText.enabled = false;
        titleText.enabled = false;
        while (f >= 0)
        {
            Color c = Panel.material.color;
            c.a = f;
            Panel.material.color = c;
            priceText.enabled = true;
            titleText.enabled = true;
            f += 0.1f;
            yield return null;
        }
    }

    void Upgrade()
    {
        print("Upgrading");
    }
    void UpdatePrice()
    {
        titleText.text = "Turret Level " + level;
        priceText.text = "Upgrade: $" + cost;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
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
