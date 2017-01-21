using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretAI : MonoBehaviour {
    public GameObject target;
    public GameObject bullet;
    public GameObject TurretHead;
    public Transform Muzzel;

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
            Fire();
            TurretHead.transform.LookAt(target.transform);
        }
    }


    public float timer, rof;
    void Fire()
    {
        if(timer <= 0)
        {
            timer += rof;
            GameObject temp = Instantiate(bullet, Muzzel.position, Muzzel.rotation) as GameObject;
            temp.GetComponent<Rigidbody>().AddForce(Muzzel.transform.forward*2, ForceMode.Acceleration);
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

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == target)
        {
            target = null;
        }
    }
}
