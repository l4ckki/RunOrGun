using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject projectile;
    public GameObject projectileLight;
    public Transform projectileZone;
    private float posX;
    private float posZ;
    private IEnumerator attack;
    private bool bossAlive;
    private bool isTouched;
    public float health = 10f;

    private void Start()
    {
        attack = SpawnProjectile();

        bossAlive = true;

        isTouched = false;

        StartCoroutine(attack);

    }


    // Update is called once per frame
    void Update()
    {
        if (Player.isFight == true)
        {
            StopCoroutine(attack);

            if (Input.touchCount == 0 && isTouched)
            {
                isTouched = false;
            }

            else if(Input.touchCount > 0 && !isTouched)
            {
                TakeDamage();
                isTouched = true;
            }
        }

        if(health <= 0)
        {
            Destroy(this.gameObject);
            bossAlive = false;
        }
    }

    private void TakeDamage()
    {

        health -= 10f;

    }



    public IEnumerator SpawnProjectile()
    {
        while (bossAlive)
        {
            Instantiate(projectile);
            Instantiate(projectileLight);

            posX = Random.Range(-3f, 3.5f);
            posZ = Random.Range(-3f, 3.5f); 

            projectile.transform.localPosition = projectileZone.transform.position + new Vector3(posX, 15f, posZ);
            projectileLight.transform.position = projectile.transform.position - new Vector3(0f, 11.3f, 0f);

            

            yield return new WaitForSeconds(0.6f);
        }
    }
}
