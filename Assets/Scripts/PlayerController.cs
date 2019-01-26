using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //movement variable
    public float movementSpeed = 20f;

    //torch object (i'll make this later)



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        Move();
	}

    //call this to move the player 1 frame
    private void Move()
    {
        Vector3 XMovement = Vector3.right * movementSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 YMovement = Vector3.up * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        transform.Translate(XMovement);
        transform.Translate(YMovement);



    }
}
