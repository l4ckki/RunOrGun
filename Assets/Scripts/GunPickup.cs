using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunPickup : MonoBehaviour
{
    public Slider slider;
    public float maxGunCount;
    public float gunCount;
    public GameObject[] currectGuns;
    public GameObject[] wrongGuns;

    void Start()
    {
        maxGunCount = 10f;
        gunCount = 1f;
        slider.maxValue = maxGunCount;
        slider.value = 0f;

        foreach(GameObject gun in currectGuns)
        {
            Gun.currectGun = true;
        }

        foreach(GameObject gun in wrongGuns)
        {
            Gun.currectGun = false;
        }
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Gun gun = other.gameObject.GetComponent<Gun>();

        if (other.CompareTag("Gun") & Gun.currectGun)
        {
            slider.value += gunCount;

            if(slider.value == slider.maxValue)
            {
                slider.value = 0f;
            }

            gun.DestroyGun();
        }

        else if (other.CompareTag("Gun") & !Gun.currectGun)
        {
            slider.value -= gunCount;

            if (slider.value == slider.maxValue)
            {
                slider.value = 0f;
            }

            gun.DestroyGun();
        }


        if (other.CompareTag("WhatGun1"))
        {
            Debug.Log("All good");

            gun.DestroyGun();

        }

        if (other.CompareTag("WhatGun2"))
        {
            SwitchGuns();

            gun.DestroyGun();
        }
    }

    private void SwitchGuns()
    {
        foreach(GameObject gun in currectGuns)
        {
            Gun.currectGun = false;
        }

        foreach (GameObject gun in wrongGuns)
        {
            Gun.currectGun = true;
        }
    }
}
