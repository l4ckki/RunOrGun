using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool currectGun;



    private void Awake()
    {
        currectGun = true;
    }

    private void Start()
    {

    }

    private void Update()
    {
        Rotate();
    }

    public void DestroyGun()
    {
        Destroy(this.gameObject);
    }

    public void ChangeFalse()
    {
        currectGun = false;
    }

    private void Rotate()
    {
        transform.Rotate(transform.up * 90f * Time.deltaTime);
    }
}
