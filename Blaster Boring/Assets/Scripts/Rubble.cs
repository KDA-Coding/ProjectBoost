using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubble : MonoBehaviour
{

   [SerializeField] Rigidbody rubbleRB;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Friendly"))
        {
            rubbleRB.useGravity = true;
            rubbleRB.isKinematic = false;
        }
    }

}
