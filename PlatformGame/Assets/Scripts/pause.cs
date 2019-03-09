using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public static bool isGameContinue = true;
    public GameObject panel_pause;
    // Start is called before the first frame update
    public void pauseMenu()
    {
        if(isGameContinue == true){
            isGameContinue = false;
            Time.timeScale = 0;
            panel_pause.SetActive(true);

        }else{
            isGameContinue = true;
            Time.timeScale = 1;
            panel_pause.SetActive(false);
        }
    }
    public void returnHome(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
    public void replay(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void exitGame(){
        Application.Quit();
    }
}
