using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	public float speed, mouseSpeed;
	public GameObject wall1, wall2, wall3, wall4;
	public Camera mainCamera;
	CursorLockMode wantedMode = CursorLockMode.Locked;

	public Animator playerAnim;
	public bool attacking;

	public int water;
	public int money;

    public PlayerUI thisUI;
    public Observer god;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Cursor.lockState = wantedMode;
        water = 0;
         canMove = true;
}

	// Update is called once per frame
	void Update () {
		getInput ();	
		keepInBounds ();
	}

    public bool canMove;
	void getInput()
	{
        if (canMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
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
                this.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }

            mainCamera.transform.Rotate(-Input.GetAxis("Mouse Y") * mouseSpeed, 0, 0);
            this.transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSpeed, 0);

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

	void keepInBounds()
	{
		if (this.transform.position.x > wall1.transform.position.x - 2) 
		{
			this.transform.position = new Vector3 (wall1.transform.position.x - 2, this.transform.position.y, this.transform.position.z);
		}
		if (this.transform.position.x < wall2.transform.position.x + 2) 
		{
			this.transform.position = new Vector3 (wall2.transform.position.x + 2, this.transform.position.y, this.transform.position.z);
		}
		if (this.transform.position.z > wall3.transform.position.z - 5) 
		{
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, wall3.transform.position.z - 5);
		}
		if (this.transform.position.z < wall4.transform.position.z + 2) 
		{
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, wall4.transform.position.z + 2);
		}
	}

}