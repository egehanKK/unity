using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createFloor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lastFloor;
    void Start()
    {
            create_floor();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void create_floor(){

        Vector3 direction;
        if(Random.Range(0,2)== 0){
            direction = Vector3.left;
        }
        else
        {
            direction = Vector3.back;
        }
        lastFloor = Instantiate(lastFloor,lastFloor.transform.position+direction,lastFloor.transform.rotation);
    }
}
