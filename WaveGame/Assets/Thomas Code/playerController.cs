using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    public float speed, mouseSpeed;
    public Camera mainCamera;
    CursorLockMode wantedMode = CursorLockMode.Locked;

    public Animator playerAnim;
    public bool attacking;

    public int water;
    public int money;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        Cursor.lockState = wantedMode;
    }
	
	// Update is called once per frame
	void Update () {
		getInput ();	
	}

	void getInput()
	{
		if(Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new Vector3(0,0,speed*Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(new Vector3(-speed * Time.deltaTime, 0,0));
        }

        mainCamera.transform.Rotate(-Input.GetAxis("Mouse Y")*mouseSpeed,0 ,0 );
        this.transform.Rotate(0, Input.GetAxis("Mouse X")*mouseSpeed, 0);

        if (playerAnim.GetBool("Attack"))
        {
            playerAnim.SetBool("Attack", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            playerAnim.SetBool("Attack", true);

            
        }



    }

}
