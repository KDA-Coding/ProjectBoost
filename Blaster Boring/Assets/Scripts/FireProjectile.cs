using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] GameObject proj;

    [SerializeField] Transform projSpawnL;
    [SerializeField] Transform projSpawnR;

    bool canShoot = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && canShoot)
        {

            spawnProj();
            canShoot = false;


            Invoke("setShootTrue", 0.7f);

        }    
    }

    void setShootTrue()
    {
        canShoot = true;
    }

    void spawnProj()
    {
        Instantiate(proj, projSpawnL.position, projSpawnL.rotation);
        Instantiate(proj, projSpawnR.position, projSpawnR.rotation);
    }

}