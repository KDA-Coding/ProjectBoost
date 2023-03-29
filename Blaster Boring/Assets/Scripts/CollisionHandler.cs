using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] AudioClip successClip;
    [SerializeField] AudioClip explosionClip;

    [SerializeField] float volumeControl = 0.6f;

    [SerializeField] float delayInSec = 3.0f;


    AudioSource collisionAudio;


    void Start()
    {
        collisionAudio = GetComponent<AudioSource>();   
    }

    void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("We collided with a Friendly Object.");
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

        //todo add Landing SFX
        collisionAudio.PlayOneShot(successClip, volumeControl);

        //todo add Particle Effect/s on landing

        Movement moveScript = GetComponent<Movement>();
        moveScript.enabled = false;

        Invoke("LoadNextLevel", delayInSec);
    }


    void StartCrashSequence()
    {

        //todo add Crash SFX
        collisionAudio.PlayOneShot(explosionClip, volumeControl);
        //todo add Particle Effect/s on crash

        Movement moveScript = GetComponent<Movement>();
        moveScript.enabled = false;

        Invoke("RestartLevel", delayInSec);
    }

}