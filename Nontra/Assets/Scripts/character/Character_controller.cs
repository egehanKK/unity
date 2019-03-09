using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Character_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public bool shoot;
    Animator animator;
    float horizontal;
    public Image life_bar;
    public float life = 145;
    bool isDead = false;
    public Transform bullet;
    public GameObject bullet_object;
    float trigger_speed= 0.6f;
    float trigger_speed_active= 0;
    
    RectTransform rect;

    void Start()
    {
        animator = GetComponent<Animator>();
        rect = life_bar.rectTransform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger_speed_active > 0){
            trigger_speed_active -= Time.deltaTime;
        }
        
        if(life <= 0)
        {
            isDead = true;

        }
        rect.sizeDelta = new Vector2(life,rect.sizeDelta.y);
        if(Input.GetKey(KeyCode.Space) ){
            
            shoot = true;
            if( trigger_speed_active <= 0){
                trigger_speed_active = trigger_speed;
                GameObject go =  Instantiate(bullet_object,bullet.transform.position,new Quaternion());
            if(transform.localScale.x<0){
                go.GetComponent<bulletMove>().left_bullet();
            }

            }
            
            
        }else{
            shoot = false;
        }
        animator.SetBool("shoot",shoot);

        
    }
    private void FixedUpdate() {
        bool isRunning = false;
        horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3 (horizontal * speed * Time.deltaTime, 0, 0);
        if(horizontal != 0)
        {
            isRunning = true;

        }
        animator.SetBool("isRunnig",isRunning);
        changeDirection();
        didFall();
        if(isDead){
            die();
        }
    }
    void changeDirection(){
        if(horizontal < 0){
            transform.localScale = new Vector3(-1,1,1);
        }else if (horizontal > 0){
            transform.localScale = new Vector3(1,1,1);
        }
    }
       void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "dino"){
            life--;
            
            
        }

        
        
    }
    void die(){
        Debug.Log("You died");
        Destroy(gameObject); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
    }
    void didFall(){
        
        if(gameObject.transform.position.y < -15f){
            die();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Finish"){
            Debug.Log("Finish");
             die();
        }

        
    }
    
}
