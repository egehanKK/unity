using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCircle : MonoBehaviour
{

    public GameObject secondaryCircle;
    GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindWithTag("gameManagerTag");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            createSecondaryCircle();
        }
        
    }

    void createSecondaryCircle(){
        Instantiate(secondaryCircle,transform.position,transform.rotation);
        GameManager.GetComponent<gameManager>().secondaryCircleText();

    }
}
