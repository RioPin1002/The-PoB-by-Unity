using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMoving : MonoBehaviour
{
    public float nodeSpeed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0.0f, 0.0f, nodeSpeed * -1.0f);
        rb.AddForce(force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
