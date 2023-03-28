using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("We collided with a Friendly Launch Pad.");
                break;
            case "Fuel":
                Debug.Log("We collided with a Fuel Source.");
                break;
            case "Finish":
                LoadNextLevel();
                break;
            default:
                Debug.Log("We've collided with something else. Reloading Level");
                RestartLevel();
                break;
        }

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

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}