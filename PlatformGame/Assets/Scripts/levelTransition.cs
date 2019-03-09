using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelTransition : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void startNewLevel(string level){
        
        SceneManager.LoadScene(level);
    }
    public void openLevel(){
        string level_name = "level"+(PlayerPrefs.GetInt("level")+1).ToString();
        SceneManager.LoadScene(level_name);
        
    }
    public void openLevelMenu(){
        SceneManager.LoadScene("levels");
    }
}
