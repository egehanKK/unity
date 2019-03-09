using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDirection : MonoBehaviour


{
    // Start is called before the first frame update

    public LayerMask layer;
    public movement dino_movement;
    public Transform dino;
    void Start()
    {
        dino = transform.parent;
        dino_movement = dino.GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast( transform.position,Vector2.down,0.3f,layer);
        if(hit.collider == null){
            //turn
            
            dino.localScale = new Vector3(dino.localScale.x* -1 ,dino.localScale.y,dino.localScale.z);
            dino_movement.speed *= -1; 
        }
        
    }
}
