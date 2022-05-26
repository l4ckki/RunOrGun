using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectileZone;
    private IEnumerator attack;
    private bool bossAlive;
    private bool isTouched;
    private float health = 100f;

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
        }
    }


    private void Attack()
    {



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

            Debug.Log("Spawn");

            projectile.transform.position = projectileZone.transform.position + new Vector3(Random.Range(0, 10f), 10f, Random.Range(0, 10f));

            yield return new WaitForSeconds(1f);
        }
    }
}
