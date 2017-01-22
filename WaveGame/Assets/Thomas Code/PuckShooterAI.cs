using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckShooterAI : MonoBehaviour {

    public GameObject target;
    public GameObject bullet;
    public GameObject TurretHead;
    public Transform Muzzel;

    public float bulletSpeed;
    public int bulletDamage;

    public Material pink, blue;

    public float timer, rof;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SetTurretRotation();	
	}

    void SetTurretRotation()
    {
        if (target == null)
        {
            TurretHead.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            TurretHead.transform.LookAt(target.transform);
            TurretHead.transform.Rotate(0, 180, 0);
            Fire();

        }
    }

    bool color;
    void Fire()
    {
        if(timer <=0)
        {
            timer += rof;
            GameObject temp = Instantiate(bullet, Muzzel.position, Muzzel.rotation) as GameObject;
            if(color)
            {
                temp.transform.FindChild("puck").GetComponent<MeshRenderer>().material = pink;
            }
            else
            {
                temp.transform.FindChild("puck").GetComponent<MeshRenderer>().material = blue;
            }
            color = !color;
            temp.GetComponent<Bullet>().damage = bulletDamage;
            temp.GetComponent<Rigidbody>().velocity = temp.transform.forward * bulletSpeed;
            temp.transform.localScale = new Vector3(1,1,1);

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
