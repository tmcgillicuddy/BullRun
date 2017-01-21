using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretAI : MonoBehaviour {
    public GameObject target;
    public GameObject bullet;
    public GameObject TurretHead;
    public Transform Muzzel;
    public int ammo, maxAmmo;
    public float bulletSpeed;
    public int bulletDamage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SetTurretRotation();
    }

    void SetTurretRotation()
    {
        if(target == null)
        {
            TurretHead.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            TurretHead.transform.LookAt(target.transform);
            Fire();
            
        }
    }


    public float timer, rof;
    void Fire()
    {
        if(timer <= 0 && ammo >0)
        {
          //  print("Fire");
            timer += rof;
            GameObject temp = Instantiate(bullet, Muzzel.position, Muzzel.rotation) as GameObject;
            temp.GetComponent<Bullet>().damage = bulletDamage;
            temp.GetComponent<Rigidbody>().velocity = temp.transform.forward * bulletSpeed;
        }
        else
        {
            timer -= Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bad Guy" && target ==null)
        {
            target = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(target == null && other.tag == "Bad Guy")
        {
            target = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == target)
        {
            target = null;
        }
    }
}
