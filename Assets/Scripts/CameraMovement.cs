using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float speed = 5f;
    public Rigidbody rigidbody;
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector3(x * speed,0,z * speed);

    }
}
