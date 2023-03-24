using UnityEngine;

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
                Debug.Log("We collided with the Finish Landing Pad.");
                break;
            default:
                Debug.Log("We've collided with something else.");
                break;
        }

    }

}
