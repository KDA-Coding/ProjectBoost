using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Parameters - For Tuning. Typically set in Editor
    // with [SerializeField].

    //Cache - References for Readability and Speed.

    //State - Private Instance/Member variables.


    //Store a "tuner" for "AddForce" on Thrust
    [SerializeField] float mainThrust = 100.0f;

    //Store a "tuner" for Rotation speed
    [SerializeField] float rotThrust = 50.0f;

    //Store an AudioClip variable here for Engine noise.
    [SerializeField] AudioClip mainEngine;

    //Store the player AudioSource for SFX handling
    AudioSource rocketAudio;

    //Particles for movement Thrusters
    [SerializeField] ParticleSystem mainThrusterParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;

    //Store the Rigidbody for Physics based manipulation
    Rigidbody rocketRB;

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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void StartThrusting()
    {
        //Add Force to Rocket while Space is held down
        //and play Thruster Sound
        if (!rocketAudio.isPlaying)
        {
            rocketAudio.PlayOneShot(mainEngine);
        }

        rocketRB.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        if (!mainThrusterParticles.isPlaying)
        {
            mainThrusterParticles.Play();
        }
    }

    void StopThrusting()
    {
        rocketAudio.Stop();
        mainThrusterParticles.Stop();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();

        }
        else
        {
            StopRotating();
        }
    }

    void RotateLeft()
    {
        //Debug.Log("Pressed A. Rotating Counter-Clockwise around Z");

        ApplyRotation(rotThrust);

        if (!rightThrusterParticles.isPlaying)
        {
            rightThrusterParticles.Play();
        }
    }

    void RotateRight()
    {
        //Debug.Log("Pressed D. Rotating Clockwise around Z");

        ApplyRotation(-rotThrust);

        if (!leftThrusterParticles.isPlaying)
        {
            leftThrusterParticles.Play();
        }
    }

    private void StopRotating()
    {
        leftThrusterParticles.Stop();
        rightThrusterParticles.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {

        rocketRB.freezeRotation = true; //Freeze Rotation to manually rotate below

        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);

        rocketRB.freezeRotation = false; //Unfreeze Rotation to re-allow physics interactions
    }
}