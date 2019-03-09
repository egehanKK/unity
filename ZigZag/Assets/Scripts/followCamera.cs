using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform followedObject;
    Vector3 distance;
    void Start()
    {
        distance = transform.position - followedObject.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate() {
        if(Player.didFall == false){
                transform.position = followedObject.position + distance;
        }
        
        
    }
}
