using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIController : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed;
    private float rotateSpeed = 10;
    private float distanceToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
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
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle -90));

        transform.position += transform.up * Time.deltaTime * 5;
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
}
