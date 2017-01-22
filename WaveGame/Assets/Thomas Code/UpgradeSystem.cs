using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    public bool playerPresent;
    public turretAI thisTurret;
    public Canvas UpgradeScreen;
    public Text priceText, titleText;
    public playerController thisplayer;
    public Image Panel;

    public Transform UpgradeSpot1, UpgradeSpot2;

    public GameObject upgrade1, upgrade2;
    public int level, cost;
    // Use this for initialization
    void Start()
    {
        UpgradeScreen.enabled = false;
        UpdatePrice();
        if (thisplayer == null)
        {
            thisplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //  UpdatePrice();
        CheckPurchase();
    }


    void CheckPurchase()
    {
        if (playerPresent)
        {
            if (Input.GetKeyDown(KeyCode.E) && level < 3)
            {
                if (thisplayer.money >= cost)
                {
                    Upgrade();
                }
                else
                {
                    StartCoroutine("NoMoney");
                    // UpdatePrice();
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (thisplayer.water > 0)
                {
                    if (thisplayer.water > thisTurret.maxAmmo - thisTurret.ammo)
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

    void Upgrade()
    {
        //  print("Upgrading");
        thisplayer.money -= cost;
        level++;
        cost *= 2;
        UpdatePrice();

        if (level == 2)
        {
            GameObject temp = Instantiate(upgrade1, UpgradeSpot1.position, Quaternion.identity) as GameObject;
            temp.transform.Rotate(0, 90, 0);
            temp.transform.parent = UpgradeSpot1;

            thisTurret.Muzzels[1] = temp.transform.Find("Muzzel1");
            thisTurret.Muzzels[2] = temp.transform.Find("Muzzel2");
            thisTurret.rof = thisTurret.rof / 3;

        }
        else
        {

        }
    }
    void UpdatePrice()
    {
        //  print("UpdatePrice");
        if (level < 3)
        {
            titleText.text = "Turret Level " + level;
            priceText.text = "Upgrade: $" + cost;
        }
        else
        {
            titleText.text = "Max Upgrade";
            priceText.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
        if (other.tag == "Player")
        {
            // StopCoroutine("FadeIn");
            playerPresent = false;
            UpgradeScreen.enabled = false;
            // StartCoroutine("FadeOut");
        }
    }
}
