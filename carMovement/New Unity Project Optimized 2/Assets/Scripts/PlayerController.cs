using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 20.0f;
    private const float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;



    // Update is called once per frame
    void FixedUpdate()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        if (forwardInput > 0)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
        else if (forwardInput < 0)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * -horizontalInput);
        }
        else
        {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * 0);
        }

    }
}