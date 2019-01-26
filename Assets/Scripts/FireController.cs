using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour {
    public float Fuel = 100;
    public float fuelPerSecond = 1;



	// Use this for initialization
	IEnumerator Start () {
		while(true)
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
        Fuel -= fuelPerSecond * Time.deltaTime;
    }

    void giveFuel(float amount)
    {
        
    }

    void receiveFuel(float amount)
    {
        
    }

    //for testing purposes only
    void OutputFuel()
    {
        Debug.Log("Remaining Fuel: " + Fuel);
    }
}
