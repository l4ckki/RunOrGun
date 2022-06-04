using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Surface surface = collision.gameObject.GetComponent<Surface>();
        GunPickup gunPickup = collision.gameObject.GetComponent<GunPickup>();

        if (surface)
        {
            Destroy(this.gameObject);
        }

        if (gunPickup)
        {
            gunPickup.MinusGun();

            Destroy(this.gameObject);
        }

        if(transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ProjectileLight projectileLight = other.gameObject.GetComponent<ProjectileLight>();


        if (projectileLight)
        {
            Destroy(this.gameObject);
            Destroy(projectileLight.gameObject);
        }


    }
}
