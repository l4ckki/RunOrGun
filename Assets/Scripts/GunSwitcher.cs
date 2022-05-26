using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    public GameObject[] wrongGuns;
    public GameObject[] currectGuns;
    private Vector3 wrongGunPos;
    private Vector3 currectGunPos;

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
}
