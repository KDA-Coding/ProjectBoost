using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] GameObject proj;

    [SerializeField] Transform projSpawnL;
    [SerializeField] Transform projSpawnR;

    [SerializeField] float delayBetweenShots = 0.5f;

    bool canShoot = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            spawnProj();
            canShoot = false;
            Invoke("setShootTrue", delayBetweenShots);
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