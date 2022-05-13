using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRight : MonoBehaviour
{
    public Camera mainCamera;
    private GameObject player;
    public float rotateSpeed;
    public Vector3 rotationY;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rotationY = new Vector3(0f, 1f, 0f);
        rotateSpeed = 2f;
    }

    private void StartRotateRight()
    {
        StartCoroutine("RotationRight");
    }

    private IEnumerator RotationRight()
    {  
        
        
        yield return new WaitForSeconds(1f);
    }
}
