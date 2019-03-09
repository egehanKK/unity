using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundSound : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject instance;
    void Start()
    {
        if(instance == null){
            instance = gameObject;
            DontDestroyOnLoad(instance);

        }else{
            Destroy(gameObject);
            
        }

        
    }

    
}
