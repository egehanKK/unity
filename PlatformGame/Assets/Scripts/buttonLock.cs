using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buttonLock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string name = gameObject.name;
        int levelOrder = int.Parse(name);
        if(PlayerPrefs.GetInt("level")+1 < levelOrder){
            GetComponent<Button>().interactable = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
