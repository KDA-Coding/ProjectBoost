using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] GameObject proj;

    [SerializeField] Transform projSpawnL;
    [SerializeField] Transform projSpawnR;

    [SerializeField] float delayBetweenShots = 0.5f;

    FireProjectile fireProjScript;
    CollisionHandler colHandlerScript;

    bool canShoot = true;


    void Start()
    {
        fireProjScript = GetComponent<FireProjectile>();
        colHandlerScript = GetComponent<CollisionHandler>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot && !colHandlerScript.isTransitioning)
        {
            spawnProj();
            canShoot = false;
            Invoke("setShootTrue", delayBetweenShots);
        }
        else if (colHandlerScript.isTransitioning)
        {
            canShoot = false;
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