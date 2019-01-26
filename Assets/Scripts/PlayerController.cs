using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //movement variable
    public float movementSpeed = 20f;

    //torch object
    public GameObject Torch;

    //campfire object
    public GameObject CampFire;


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

    //when you bump into the fire with wood in your inventory
    private void giveFuel()
    {
        
    }

    //when you bump into the fire and press space
    private void takeFuelForTorch(int amount)
    {
        CampFire.GetComponent<FireController>().Fuel -= amount;
        Torch.GetComponent<Torch>().torchFuel += amount;
    }

    void OnCollisionBegin(Collision col)
    {
        Debug.Log("ALERT ALERT ALERT");
    }

    void takeFuelFromFire()
    {
        if (Input.GetKeyDown("e"))
        {
            takeFuelForTorch(10);
            Debug.Log("Just took 10 fuel");
        }
    }
}
