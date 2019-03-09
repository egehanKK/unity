using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    // Start is called before the first frame update
    float bullet_speed = 6f;
    void Start()
    {
        Destroy(gameObject,3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() {
        transform.position += new Vector3(bullet_speed*Time.deltaTime,0,0);
        
    }
    public void left_bullet(){
        bullet_speed *= -1; 
    }
}
