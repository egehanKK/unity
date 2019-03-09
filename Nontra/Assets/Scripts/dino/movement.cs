using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float runSpeed;
    public float finalSpeed;
    public LayerMask layer;
    public Animator animator;
    public bool didSee;
    public bool move = true;
    bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        if(transform.localScale.x < 0 ){
            speed *= -1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if(isDead){
            return;
        }
        finalSpeed = speed;
        
        
        if(didSee){
            finalSpeed = speed*runSpeed;

        }
        if(move== true || !didSee){
            transform.position += new Vector3(finalSpeed*Time.deltaTime,0,0);
            
        }
        didSee = seeCharacter();
        animator.SetBool("isRunning",didSee);
        
        
    }
    bool seeCharacter(){
        Vector2 direction;
        if(transform.localScale.x > 0 ){
            direction =  Vector2.right;
        }else{
            direction = Vector2.left;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position,direction,6f,layer);
        if(hit.collider == null){
            return false;
        }else{
            return true;
        }
        
    }
        void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"){
            move = false;
        }

        
    }
        void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"){
            move = true;
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "bullet"){
            animator.SetBool("isDead",true);
            Destroy(other.gameObject);
            isDead = true;
        }
        
    }
    void die(){
        Destroy(gameObject);
    }
    
}
