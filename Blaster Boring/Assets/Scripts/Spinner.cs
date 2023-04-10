using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xRot = 0.0f;
    [SerializeField] float yRot = 1.0f;
    [SerializeField] float zRot = 0.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xRot, yRot, zRot);
    }
}
