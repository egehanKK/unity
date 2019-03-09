using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 direction;
    public float velocity;
    public createFloor newFloor;
    public static bool didFall;
    int highScore;
    public float hardness ;
    public float increaseScore;
    float score;
    public Text scoreText;
    
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        didFall = false;
        direction = Vector3.back;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(didFall){
            return ;
        }
        if(Input.GetMouseButtonDown (0)){
            if(direction.x ==0){
                direction = Vector3.left;
            }else{
                direction = Vector3.back;
            }
        }
       if(transform.position.y < 0){
                didDie();
         }
        
    }
    void didDie(){
        if(highScore < (int)score){
            highScore = (int)score;
            PlayerPrefs.SetInt("highScore",highScore);

        }
        didFall = true;
    }
    void FixedUpdate()
    {
        if(didFall){
            return ;
        }
        Vector3 movement = direction * Time.deltaTime * velocity;
        transform.position += movement;
        velocity += hardness*Time.deltaTime;
        score += (increaseScore*velocity*Time.deltaTime);
        scoreText.text = ((int)score ).ToString();
        
    }
    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "floor"){
            StartCoroutine (removeFloor(other.gameObject));
            newFloor.create_floor();
        }
    }

    IEnumerator removeFloor(GameObject floor){
        yield return new WaitForSeconds(0.1f);
            
        floor.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(2);
        Destroy(floor);
    }
}
