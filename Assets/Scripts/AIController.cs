using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIController : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed;
    private float rotateSpeed = 10f;
    public float maxSpeed = 100f;
    public float acceleration = 2f;
    private float distanceToPlayer;
    private Rigidbody2D rigidbody;
    public float viewDistance = 10;

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

    //fuck me i dont want to do this
    Boolean LookForPlayer()
    {
        Vector3 targ = Player.transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        Vector3 distanceVector = targ - objectPos;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;



        float angle = (Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg) - 90;
        if(angle < 90 && Vector3.Magnitude(distanceVector) < viewDistance)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            //transform.position = Vector3.Lerp(transform.position, targ, .05f);
            if (Vector3.Magnitude(rigidbody.velocity) < maxSpeed)
            {
                rigidbody.AddForce(transform.up * acceleration);
            }
        }
        else{
            if (Vector3.Magnitude(rigidbody.velocity) > 0)
            {
                rigidbody.velocity = rigidbody.velocity * 0.9f * Time.deltaTime;
            }
        }

        ////calculate direction between enemy and player
        //var targetDir = Player.transform.position - transform.position;

        ////get forward vector of enemy
        //var forward = transform.up;

        ////check if angle is less than 180
        //float angle = Vector3.Angle(targetDir, forward);
        //if(angle < 90)
        //{
        //    Debug.Log("Player in sight REEEE");

        //}
        //if it is, the player is in the field of view
        return true;
    }

    //void FollowTargetWithRotation(Transform target, float distanceToStop, float speed)
    //{
        //if (Vector3.Distance(transform.position, target.position) > distanceToStop)
        //{
        //    transform.LookAt(target);
        //    //rigidbody.AddRelativeForce(Vector3.up * speed);
        //}
    //}

    //void FollowTargetWitouthRotation(Transform target, float distanceToStop, float speed)
    //{
    //    var direction = Vector3.zero;
    //    if (Vector3.Distance(transform.position, target.position) > distanceToStop)
    //    {
    //        direction = target.position - transform.position;
    //        rigidbody.AddRelativeForce(direction.normalized * speed, ForceMode.Force);
    //    }
    //}
}
