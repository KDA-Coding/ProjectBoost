using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projSpeed = 10;

    [SerializeField] ParticleSystem blasterParticle;

    [SerializeField] Light blasterLight;

    [SerializeField] MeshRenderer blasterMR;

    AudioSource boltSource;

    [SerializeField] AudioClip blasterClip;
    [SerializeField] AudioClip impactClip;

    [SerializeField][Range(0, 1)] float volumeControl = 0.6f;

    [SerializeField] float timeToDestroy = 1f;

    [SerializeField] float destructDelay = 3f;

    bool hasCollided = false;


    void Start()
    {
        boltSource = GetComponent<AudioSource>();

        boltSource.PlayOneShot(blasterClip, volumeControl);

         Destroy(gameObject, destructDelay);
    }

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
        boltSource.Stop();
        //Debug.Log("Collided with terrain.");
        hasCollided = true;
        DestructionParticle();
        boltSource.PlayOneShot(impactClip, volumeControl);
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