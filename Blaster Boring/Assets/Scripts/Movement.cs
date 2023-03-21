using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            Debug.Log("Pressed Spacebar. Thrust Active");
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Pressed A. Rotating Counter-Clockwise around Z");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Pressed D. Rotating Clockwise around Z");
        }
    }
}

    