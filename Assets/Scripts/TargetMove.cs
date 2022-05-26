using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    private Rigidbody t_rb;
    public GameObject pivotPoint;

    private void Awake()
    {
        t_rb = gameObject.GetComponent<Rigidbody>();
    }




    private void FixedUpdate()
    {


        if(Player.isFight == false)
        {
            Move();
        }
        
        else if(Player.isFight == true)
        {
            StopMove();
        }
    }


    private void Move()
    {
        t_rb.velocity = new Vector3(0f, 0f, Player.zForce) * Time.deltaTime;
    }

    private void StopMove()
    {
        t_rb.velocity = Vector3.zero;
        t_rb.angularVelocity = Vector3.zero;
    }
}
