using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    static public bool currectGun;

    public void DestroyGun()
    {
        Destroy(this.gameObject);
    }
}
