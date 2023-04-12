using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] AudioClip successClip;
    [SerializeField] AudioClip explosionClip;

    [SerializeField] ParticleSystem winParticle;
    [SerializeField] ParticleSystem explodeParticle;

    [SerializeField][Range(0,1)] float volumeControl = 0.6f;

    [SerializeField] float delayInSec = 3.0f;


    AudioSource collisionAudio;

    Movement moveScript;

    public bool isTransitioning = false;
    bool collisionDisabled = false;

    void Start()
    {
        collisionAudio = GetComponent<AudioSource>();
        moveScript = GetComponent<Movement>();
    }

    void Update()
    {
        //RespondToDebugKeys();    
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            //Toggle Collision Bool
            collisionDisabled = !collisionDisabled;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(isTransitioning || collisionDisabled) { return; }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Colliding with Friendly Object");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }

    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    void RestartLevel()
    {
        //Use GetActiveScene().buildIndex to store current scene build index
        //Assign to currentSceneIndex and pass to .LoadScene as parameter
        //No matter which level we're on, the Reloader reloads the current
        //active level.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;

        collisionAudio.Stop();

        collisionAudio.PlayOneShot(successClip, volumeControl);

        winParticle.Play();

        moveScript.enabled = false;

        Invoke("LoadNextLevel", delayInSec);
    }


    void StartCrashSequence()
    {
        isTransitioning = true;

        collisionAudio.Stop();

        collisionAudio.PlayOneShot(explosionClip, volumeControl);

        explodeParticle.Play();

        moveScript.enabled = false;

        Invoke("RestartLevel", delayInSec);
    }

}