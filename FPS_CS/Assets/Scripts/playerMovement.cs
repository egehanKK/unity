using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerMovement : NetworkBehaviour
{
    // Start is called before the first frame update
    float velocity = 4f;
    float sensitivity = 1.8f;
    Vector3 MovementVector;
    float x_mouse;
    float y_mouse;
    public Camera eyeCam;
    float upDownRotation;
    void Start()
    {
        if(!isLocalPlayer){
            eyeCam.enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer){
            movement_velocity();
            movement_rotation();

        }

        

    }
    void movement_velocity(){
        float x_movement = Input.GetAxis("Horizontal");
        float z_movement = Input.GetAxis("Vertical");

        Vector3 x_vector = transform.right * x_movement;
        Vector3 z_vector = transform.forward * z_movement;

        MovementVector = (x_vector + z_vector)*velocity; 

    }
    void movement_rotation(){
        x_mouse = Input.GetAxis("Mouse X")*sensitivity; // swat rotation
        y_mouse = Input.GetAxis("Mouse Y")*sensitivity; // camera rotation

    }
    private void FixedUpdate()
    {
        transform.position += MovementVector * Time.fixedDeltaTime;
        transform.Rotate(new Vector3(0,x_mouse,0));
        eyeCam.transform.Rotate(new Vector3(-y_mouse,0,0));

        upDownRotation -= y_mouse;
        upDownRotation = Mathf.Clamp(upDownRotation,-50f,50f);
        eyeCam.transform.localEulerAngles = new Vector3(upDownRotation,0,0);
         
    }
}
