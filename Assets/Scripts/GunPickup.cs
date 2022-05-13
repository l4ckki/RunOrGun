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
    private Vector3 wrongGunPos;
    private Vector3 currectGunPos;

    void Start()
    {
        maxGunCount = 10f;
        gunCount = 1f;
        slider.maxValue = maxGunCount;
        slider.value = 0f;

    }

    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Gun gun = other.gameObject.GetComponent<Gun>();

        if (other.CompareTag("GunCurrect"))
        {
            slider.value += gunCount;


            if (slider.value == slider.maxValue)
            {
                slider.value = 0f;
            }

            gun.DestroyGun();
        }

        if (other.CompareTag("GunWrong")) 
        {
            slider.value -= gunCount;

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
        for (int i = 0; i < currectGuns.Length; i++)
        {
            Debug.Log("SwapGuns");

            wrongGunPos = wrongGuns[i].transform.position;
            currectGunPos = currectGuns[i].transform.position;


            currectGuns[i].transform.position = wrongGunPos;
            wrongGuns[i].transform.position = currectGunPos;

        }
    }
}
