using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIController : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed;
    public float maxSpeed = 100f;
    public float acceleration = 2f;
    private float distanceToPlayer;
    private Rigidbody2D rigidbody;
    public float viewDistance = 10;
    public float runAwayTime = .5f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LookForPlayer();
    }

    Boolean LookForPlayer()
    {
        Vector3 targ = Player.transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        Vector3 distanceVector = targ - objectPos;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;



        float angle = (Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg) - 90;
        if(Vector3.Magnitude(distanceVector) < viewDistance)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            //transform.position = Vector3.Lerp(transform.position, targ, .05f);
            if (Vector3.Magnitude(rigidbody.velocity) < maxSpeed)
            {
                if (Player.GetComponent<PlayerController>().isSwinging)
                {
                    StartCoroutine("RunAway");
                }
                else
                {
                    rigidbody.AddForce(transform.up * acceleration);
                }
            }
        }
        else{
            if (Vector3.Magnitude(rigidbody.velocity) > 0)
            {
                rigidbody.velocity = rigidbody.velocity * 0.9f * Time.deltaTime;
            }
        }
        return true;
    }

    IEnumerator RunAway()
    {
        float time = 0f;
        //time to do something fancy; the closer you are to the player, the longer you run away 
        //get distance between the two
        Vector3 distanceVector = Player.transform.position - transform.position;
        float timeModifier = Vector3.Magnitude(distanceVector) / viewDistance;
        while(time < (runAwayTime - timeModifier))
        {
            time += Time.deltaTime;
            rigidbody.AddForce(-transform.up * .1f);
            yield return null;

        }
        Player.GetComponent<PlayerController>().isSwinging = false;
        Debug.Log("done Running away");
    }

}
