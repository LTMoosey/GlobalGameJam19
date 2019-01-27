using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //movement variable
    public float movementSpeed = 20f;

    //torch objects
    public GameObject Torch;
    private Torch torchComponent;

    //campfire object
    public GameObject CampFire;
    private FireController campfireComponent;

    //number of sticks the player is currently holding
    public int numSticks;

    public bool isSwinging;

    private Animator anim;

    private void Awake()
    {
        numSticks = 0;
        campfireComponent = CampFire.GetComponent<FireController>();
        torchComponent = Torch.GetComponent<Torch>();
        anim = GetComponent<Animator>();
        isSwinging = false;
    }

    // Use this for initialization
    void Start () {
        numSticks = 0;

	}
	
	// Update is called once per frame
	void Update () {
        
        Move();

        //if you press the space button, you swing your torch
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //take 5 fuel from torch if there is enough fuel
            if(torchComponent.torchFuel >= 5)
            {
                torchComponent.torchFuel -= 5;
            }

            //do swing animation

            //set isSwinging to true
            Debug.Log("Miss me with that torch shit");
            isSwinging = true;
        }

	}

    //call this to move the player 1 frame
    private void Move()
    {
        Vector3 XMovement = Vector3.right * movementSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 YMovement = Vector3.up * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        anim.SetFloat("DirX", Input.GetAxis("Horizontal"));
        anim.SetFloat("DirY", Input.GetAxis("Vertical"));

        transform.Translate(XMovement);
        transform.Translate(YMovement);
    }

    private void takeFuelForTorch(int amount)
    {
        if (campfireComponent.Fuel > amount)
        {
            campfireComponent.Fuel -= amount;
            torchComponent.torchFuel += amount;
        }
        else
        {
            Debug.Log("Not Enough Fuel!!");
        }
    }

    //this function is called when you remain in contact with the fire,
    //since OnCollisionEnter2D is literally a frame window
    //press space to deposit sticks
    //press e to withdraw fuel from fire
    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.name == "CampFire")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                campfireComponent.Fuel += numSticks * 20;
                Debug.Log("Added " + (numSticks * 20) + " to Fire");
                //set sticks to 0
                numSticks = 0;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                takeFuelFromFire();
            }
        }
    }

    //calls takeFuelForTorch with an int as a parameter
    //we can change this specific number later, this is mostly for testing
    void takeFuelFromFire()
    {
        takeFuelForTorch(10);
        Debug.Log("Just took 10 fuel");
    }
}
