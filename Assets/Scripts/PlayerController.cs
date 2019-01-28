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
    private AudioSource audio;

    public bool isDead;

    private void Awake()
    {
        numSticks = 0;
        campfireComponent = CampFire.GetComponent<FireController>();
        torchComponent = Torch.GetComponent<Torch>();
        anim = GetComponent<Animator>();
        isSwinging = false;
        audio = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        numSticks = 0;
        isDead = false;

	}
	
	// Update is called once per frame
	void Update () {
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Move();
        }

        //if you press the space button, you swing your torch
        if(Input.GetKeyDown(KeyCode.Q))
        {
            //take 5 fuel from torch if there is enough fuel
            if(torchComponent.torchFuel >= 5)
            {
                torchComponent.torchFuel -= 5;
            }

            //do swing animation
            anim.SetTrigger("Swing");

            //set isSwinging to true
            Debug.Log("Miss me with that torch shit");
            isSwinging = true;
        }

	}

    //call this to move the player 1 frame
    private void Move()
    {
        float horizAxis = Input.GetAxis("Horizontal");
        float vertAxis = Input.GetAxis("Vertical");

        if(horizAxis != 0 || vertAxis != 0)
        {
            if(!audio.isPlaying)
            {
                audio.Play();
            }
        }
        else
        {
            audio.Stop();  
        }

        Vector3 XMovement = Vector3.right * movementSpeed * Time.deltaTime * horizAxis;
        Vector3 YMovement = Vector3.up * movementSpeed * Time.deltaTime * vertAxis;

        anim.SetFloat("DirX", horizAxis);
        anim.SetFloat("DirY", vertAxis);

        if(horizAxis != 0 || vertAxis != 0)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }

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
                campfireComponent.Fuel += numSticks ;
                Debug.Log("Added " + (numSticks) + " to Fire");
                //set sticks to 0
                numSticks = 0;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                takeFuelFromFire();
            }
        }
        else if(col.gameObject.name == "Enemy" || col.gameObject.name == "House")
        {
            isDead = true;
            //Debug.Log("you're dead!");
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
