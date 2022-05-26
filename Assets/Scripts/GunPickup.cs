using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunPickup : MonoBehaviour
{
    public Slider slider;
    public float maxGunCount;
    public float gunCount;
    public GameObject[] wrongGuns;
    public GameObject[] currectGuns;
    private Vector3 wrongGunPos;
    private Vector3 currectGunPos;

    void Start()
    {
        maxGunCount = 10f;
        gunCount = 1f;
        slider.maxValue = maxGunCount;
        slider.value = 0f;

        foreach(GameObject pistol in wrongGuns)
        {

            pistol.GetComponent<Gun>().currectGun = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        GunSwitcher gunSwitcher = gameObject.GetComponent<GunSwitcher>();
        Gun gun = other.gameObject.GetComponent<Gun>();


        if (gun & gun.currectGun == true)
        {
            PlusGun();

            gun.DestroyGun();
        }

        else if (gun & gun.currectGun == false) 
        {
            MinusGun();

            gun.DestroyGun();
        }


        if (other.CompareTag("WhatGun1"))
        {
            Debug.Log("All good");

            gun.DestroyGun();

        }

        if (other.CompareTag("WhatGun2"))
        {

            GunSwitch();

            gun.DestroyGun();
        }

    }

    public void GunSwitch()
    {
        for (int i = 0; i < currectGuns.Length; i++)
        {
            Debug.Log("SwapGuns");

            wrongGunPos = wrongGuns[i].transform.position;
            currectGunPos = wrongGuns[i].transform.position;


            currectGuns[i].transform.position = wrongGunPos;
            wrongGuns[i].transform.position = currectGunPos;



        }

        foreach (GameObject pistol in wrongGuns)
        {

            pistol.GetComponent<Gun>().currectGun = true;
        }

        foreach (GameObject rifle in currectGuns)
        {

            rifle.GetComponent<Gun>().currectGun = false;
        }
    }

    public void MinusGun()
    {
        slider.value -= gunCount;

    }

    private void PlusGun()
    {
        slider.value += gunCount;


        if (slider.value == slider.maxValue)
        {
            slider.value = 0f;
        }
    }
}
