using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class localPlayer : NetworkBehaviour
{

    public GameObject[] local_Player;
    // Start is called before the first frame update
    void Start()
    {

        if(!isLocalPlayer){
            foreach( var item in local_Player){
                item.SetActive(false);

            }

        }
        

        
    }

    // Update is called once per frame
}
