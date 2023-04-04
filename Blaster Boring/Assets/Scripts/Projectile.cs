using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projSpeed = 10;

    [SerializeField] ParticleSystem blasterParticle;

    [SerializeField] Light blasterLight;

    [SerializeField] MeshRenderer blasterMR;

    [SerializeField] float timeToDestroy = 2f;

    bool hasCollided = false;

    void Update()
    {
            MoveProjectile();
    }

    void MoveProjectile()
    {
        if(!hasCollided)
        {
            transform.position += transform.up * projSpeed * Time.deltaTime;
        }
        else if (hasCollided)
        {
            return;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided with terrain.");
        hasCollided = true;
        DestructionParticle();
    }

    void DestructionParticle()
    {
        blasterMR.enabled = false;
        blasterLight.enabled = false;
        blasterParticle.Play();

        Invoke("DestroyBolt", timeToDestroy);
    }

    void DestroyBolt()
    {
        Destroy(gameObject);
    }
}