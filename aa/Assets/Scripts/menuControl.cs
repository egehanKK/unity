using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void play(){

        if(PlayerPrefs.GetInt("levelNum") == 0){
            SceneManager.LoadScene("1");
        }else{
            SceneManager.LoadScene(PlayerPrefs.GetInt("levelNum"));
        }
       
    }
    public void exit(){
        Application.Quit();

    }
}
