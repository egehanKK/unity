using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour


{
    // Start is called before the first frame update

    public GameObject eyeCam;
    public weapon weaponObject;
    public GameObject bloodEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButton(0)  && weaponObject.canShot){
            RaycastHit hit;
            if(Physics.Raycast(eyeCam.transform.position,eyeCam.transform.forward,out hit,30f)){
                if(hit.collider.tag == "Player"){
                    GameObject new_blood_effect = Instantiate(bloodEffect,hit.point,Quaternion.identity);
                    Destroy(new_blood_effect,0.5f);

                    Debug.Log("Vurdun");
                }
            }
        }
        
    }
}
