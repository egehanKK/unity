using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondaryCircle : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D physic;
    public float speed;
    bool moveControl = false;
    GameObject gameManager;
    void Start()
    {

        physic = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindWithTag("gameManagerTag");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!moveControl){
             physic.MovePosition(physic.position+Vector2.up*speed*Time.deltaTime);

        }
       
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "circleTag")
        {
            transform.SetParent(other.transform);
            moveControl = true;

        }
        if(other.tag == "secondaryCircleTag"){
            gameManager.GetComponent<gameManager>().gameOver();
        }
    }
}
