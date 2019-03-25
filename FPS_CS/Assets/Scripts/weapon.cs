using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public string title;
    public int bulletNum;
    public int maxBulletNum;
    public float shootTimeConstant;
    float activeShootTime;
    public bool canShot = false;


    void Start()
    {
        
        activeShootTime =  shootTimeConstant;
    }

    private void Update() {
        canShot = false;
        activeShootTime-= Time.deltaTime;
        if(Input.GetMouseButton(0)){

            if(activeShootTime <= 0){
                canShot = true;
                bulletNum--;
                activeShootTime = shootTimeConstant;
            }
            if(bulletNum <= 0){
                //şarjör değiştir
                bulletNum = maxBulletNum;
            }

        }
    }
}
