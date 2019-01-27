using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Light2D;
using UnityEngine.SocialPlatforms;

public class FlickerLight : MonoBehaviour
{

    public GameObject light;
    private LightSprite lightComponent;
    private float baseAlpha;
    [Range(0, .5f)]
    public float flickerAmount;

    // Start is called before the first frame update
    void Start()
    {
        lightComponent = light.GetComponent<LightSprite>();
        baseAlpha = lightComponent.Color.a;
        StartCoroutine("Flicker");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            //get random size (need to be Vector3 not Vector2) if you want to just change x scale 
            float randomAlpha = Random.Range(baseAlpha - flickerAmount, baseAlpha + flickerAmount);

            //set it to the scale of previously instantiated platform 
            lightComponent.Color.a = randomAlpha;
            //Debug.Log("Alpha: " + lightComponent.Color.a);

            yield return new WaitForSeconds(0.1f);
        }

    }
}
