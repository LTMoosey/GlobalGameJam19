using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject CampFire;
    public GameObject Light;
    public float MaxRange;
    public float torchFuel = 100f;
    private float torchScale;
    private float torchBurnRate = 2f;


    void Start()
    {
        //here, the torch should get set to 0 so it is unlit at the beginning of the game, 
        //but not for now cuz of testing and whatnot
        StartCoroutine("oneSecPrint");
    }

    void Update()
    {
        if(torchFuel > 0)
        {
            burnFuel();
        }

    }

    IEnumerator oneSecPrint()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            OutputFuel();
        }
    }

    void burnFuel()
    {
        torchFuel -= torchBurnRate * Time.deltaTime;
        torchScale = Mathf.Clamp(torchFuel, 0, MaxRange);
        Light.transform.localScale = new Vector3(torchScale, torchScale, torchScale);
    }

    //for testing purposes only
    void OutputFuel()
    {
        Debug.Log("TORCH :: Remaining Torch Fuel: " + torchFuel);
    }
}
