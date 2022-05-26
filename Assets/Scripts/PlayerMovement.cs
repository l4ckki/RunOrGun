using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform target;
    public Transform camFightPos;
    private Vector3 deltaY;

    private void Start()
    {
        deltaY = new Vector3(0f, -3f, 15f);
    }

    private void Update()
    {

        if (Player.isFight == false)
        {
            CameraFollow();
        }

        else
        {
            CameraFight();
        }
    }


    private void CameraFollow()
    {
        transform.position = target.position - deltaY;
        transform.LookAt(target);
    }

    private void CameraFight()
    {
        transform.position = camFightPos.position;
        transform.rotation = camFightPos.rotation;

    }

}
