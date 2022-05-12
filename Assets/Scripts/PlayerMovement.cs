using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    private Vector3 deltaPos;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        deltaPos = new Vector3(0f, -4.5f, 7.75f);
    }

    // Update is called once per frame
    void Update()
    {
        player.GetComponent<Rigidbody>().AddForce(0f, 0f, 6f);
        gameObject.transform.position = player.transform.position - deltaPos;
    }
}
