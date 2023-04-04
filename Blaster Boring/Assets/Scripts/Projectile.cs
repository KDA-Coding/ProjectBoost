using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projSpeed = 10;

    [SerializeField] ParticleSystem blasterParticle;

    void Update()
    {
        MoveProjectile();
    }

    void MoveProjectile()
    {
        transform.position += transform.up * projSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collided with terrain.");

        DestructionParticle();

        Destroy(gameObject);
    }

    void DestructionParticle()
    {
        Instantiate(blasterParticle, transform.position, transform.rotation);

        blasterParticle.Play();

        Invoke("DestroyDestructionParticle", 1.0f);
    }

    void DestroyDestructionParticle()
    {
        Destroy(blasterParticle);
    }

}