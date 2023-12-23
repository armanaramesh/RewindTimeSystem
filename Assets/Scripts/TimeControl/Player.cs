using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeControl;

public class Player : TimeControlled
{
    [SerializeField] private float movespeed = 5f;
    [SerializeField] private float jumpVelocity = 10f;
    


    public override void TimeUpdate()
    {
        //base.TimeUpdate();


        Vector2 pos = transform.position;

        pos.y += velocity.y * Time.deltaTime;
        velocity.y = TimeController.gravity;// * Time.deltaTime;


        if(pos.y < 1) 
        {

            pos.y = 1;
            velocity.y = 0;
        }


        if(Input.GetKey(KeyCode.W))
        {
            velocity.y = jumpVelocity;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += movespeed * Time.deltaTime;
        }

        transform.position = pos;

    } 



}