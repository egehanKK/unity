using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    //[SerializeField] float speed = 20.0f;


    [SerializeField] float horsePower = 0.0f;
    private const float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;

    [SerializeField] TextMeshProUGUI speedometer;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float speed;
    [SerializeField] float rpm;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;





    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // Move the vehicle forward
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        if (IsOnGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);


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

            speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
            speedometer.SetText("Speed: " + speed + " kph");

            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);

        }


    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround > 2)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}