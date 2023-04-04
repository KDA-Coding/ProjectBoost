using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody projRB;
    [SerializeField] float projSpeed = 300;


    void Start()
    {
        projRB = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        projRB.AddForce(gameObject.transform.up * projSpeed * Time.deltaTime, ForceMode.VelocityChange);    
    }

    void OnCollisionEnter(Collision collision)
    {
            
    }
}
