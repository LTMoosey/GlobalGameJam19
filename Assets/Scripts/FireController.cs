using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour {
    public float Fuel = 100;
    public float burnRate = 1;



	// Use this for initialization
	void Start () {
        StartCoroutine("oneSecPrint");
	}

    IEnumerator oneSecPrint()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            OutputFuel();
        }
    }
	
	// Update is called once per frame
    void Update () {
        burnFuel();
	}

    void burnFuel()
    {
        Fuel -= burnRate * Time.deltaTime;
    }

    //void giveFuel(float amount)
    //{
    //    //when space bar is pressed
    //    //if player is colliding with the fire
    //}

    //void receiveFuel(float amount)
    //{
    //    //if player is colliding with fire
    //    //give sticks from player inventory
    //}

    //for testing purposes only
    void OutputFuel()
    {
        Debug.Log("CAMPFIRE :: Remaining Fuel: " + Fuel);
    }
}

