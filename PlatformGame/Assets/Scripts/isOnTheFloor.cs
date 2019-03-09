using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isOnTheFloor : MonoBehaviour
{
    public LayerMask layer;
    public bool isOnFloor;
    public Rigidbody2D rigidbd;

    public float jumpForce = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(character_control.didGameStart == false){
            return;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down,0.1f,layer);
        if (hit.collider != null)
        {
         //hit the floor
            isOnFloor = true;
        }else
        {   
            
            // it is on the air
            isOnFloor= false;
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
        
    }
    public void jump(){
        if(isOnFloor == true){
            rigidbd.velocity += new Vector2(0,jumpForce);
        }
    }
}
