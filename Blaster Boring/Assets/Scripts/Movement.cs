using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Store the Rigidbody for Physics based manipulation
    Rigidbody rocketRB;

    //Store a "tuner" for "AddForce" on Thrust
    [SerializeField] float mainThrust = 100.0f;

    //Store a "tuner" for Rotation speed
    [SerializeField] float rotThrust = 50.0f;

    //Store the player AudioSource for SFX handling
    AudioSource rocketAudio;

    // Start is called before the first frame update
    void Start()
    {
        rocketRB = GetComponent<Rigidbody>();
        rocketAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            //Add Force to Rocket while Space is held down
            //and play Thruster Sound
            if (!rocketAudio.isPlaying)
            {
                rocketAudio.Play();
            }

            rocketRB.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
        else
        {
            rocketAudio.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Pressed A. Rotating Counter-Clockwise around Z");

            ApplyRotation(rotThrust);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Pressed D. Rotating Clockwise around Z");

            ApplyRotation(-rotThrust);

        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {

        rocketRB.freezeRotation = true; //Freeze Rotation to manually rotate below

        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);

        rocketRB.freezeRotation = false; //Unfreeze Rotation to re-allow physics interactions
    }
}