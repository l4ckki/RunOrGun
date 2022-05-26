using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        Surface surface = collision.gameObject.GetComponent<Surface>();
        GunPickup gunPickup = collision.gameObject.GetComponent<GunPickup>();
        
        if (surface)
        {
            Destroy(this.gameObject);
        }

        if (player)
        {
            gunPickup.MinusGun();

            Destroy(this.gameObject);
        }
    }
}
