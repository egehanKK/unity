using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        horizontalInput = Input.GetAxis ("Horizontal");
        forwardInput = Input.GetAxis ("Vertical");
        // Move the vehicle forward
        transform.Translate (Vector3.forward * Time.deltaTime * speed * forwardInput);

        if (forwardInput > 0) {
            transform.Rotate (Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        } else if (forwardInput < 0) {
            transform.Rotate (Vector3.up, Time.deltaTime * turnSpeed * -horizontalInput);
        } else {
            transform.Rotate (Vector3.up, Time.deltaTime * turnSpeed * 0);
        }

    }
}