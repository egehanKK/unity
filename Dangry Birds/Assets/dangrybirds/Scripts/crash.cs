using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crash : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject text;
    public int point;
    void Start()
    {
        if(gameObject.tag == "enemy"){
                level_control.enemyNum++;
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        fall();
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.relativeVelocity.magnitude > 5f ){
            EnemyDie();
        }else if(other.relativeVelocity.magnitude > 3f && gameObject.tag == "enemy"){
            
            EnemyDie();

        }
    }
    void fall(){
        if(gameObject.transform.position.y <= -8f){
            GameObject die_text=Instantiate(text,transform.position,new Quaternion());
            die_text.GetComponent<TextMesh>().text = point.ToString();
            
            Destroy(gameObject);
        }
    }
    void EnemyDie(){
        GameObject die_text=Instantiate(text,transform.position,new Quaternion());
            die_text.GetComponent<TextMesh>().text = point.ToString();
            
            Destroy(gameObject,0.2f);
        
    }
    void OnDestroy() {
        level_control.total_point += point;
        if(gameObject.tag == "enemy"){

                level_control.enemyNum--;
            }
    }
}
