using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    // Start is called before the first frame update

    public LayerMask layer;
    public bool onFloor = false;
    public Rigidbody2D rigid;
    public float jumpForce;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit2D hit = Physics2D.Raycast (transform.position,Vector2.down,0.1f,layer);
        if(hit.collider != null){
            onFloor = true;

        }else{
            onFloor = false;
        }
        if(Input.GetKeyDown(KeyCode.W) && onFloor){
            rigid.velocity  += new  Vector2(0,jumpForce);
        }
    }
    
}
