using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretAI : MonoBehaviour
{
    public GameObject target;
    public GameObject bullet;
    public GameObject TurretHead;
    public Transform[] Muzzels;
    public int ammo, maxAmmo;
    public float bulletSpeed;
    public int bulletDamage;

    public int currentLevel;
    // Use this for initialization
    void Start()
    {
        isFrozen = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetTurretRotation();
    }

    public bool isFrozen;
    void SetTurretRotation()
    {
        if (isFrozen == false)
        {
            if (target == null)
            {
                TurretHead.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                TurretHead.transform.LookAt(target.transform);
                TurretHead.transform.Rotate(0, 90, 0);
                Fire();

            }
        }
    }


    public float timer, rof;
    int firedBullets;
    void Fire()
    {
        if (timer <= 0 && ammo > 0)
        {
            //  print("Fire");
            if (currentLevel > 1)
            {
                timer += rof;
                GameObject temp = Instantiate(bullet, Muzzels[firedBullets%3].position, Muzzels[0].rotation) as GameObject;
                temp.GetComponent<Bullet>().damage = bulletDamage;
                temp.GetComponent<Rigidbody>().velocity = temp.transform.forward * bulletSpeed;
                firedBullets++;
            }
            else
            {
                timer += rof;
                GameObject temp = Instantiate(bullet, Muzzels[0].position, Muzzels[0].rotation) as GameObject;
                temp.GetComponent<Bullet>().damage = bulletDamage;
                temp.GetComponent<Rigidbody>().velocity = temp.transform.forward * bulletSpeed;
            }
            ammo--;
        }
        else
        {
            timer -= Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bad Guy" && target == null)
        {
            target = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (target == null && other.tag == "Bad Guy")
        {
            target = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
        {
            target = null;
        }
    }
}
