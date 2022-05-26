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

    public void DestroyGun()
    {
        Destroy(this.gameObject);
    }

    public void ChangeFalse()
    {
        currectGun = false;
    }
}
