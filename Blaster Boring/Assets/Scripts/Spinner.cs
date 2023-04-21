using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xRot = 0.0f;
    [SerializeField] float yRot = -50.0f;
    [SerializeField] float zRot = 0.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xRot * Time.deltaTime, yRot * Time.deltaTime, zRot * Time.deltaTime);
    }
}
