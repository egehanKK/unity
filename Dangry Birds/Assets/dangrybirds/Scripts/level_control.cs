using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class level_control : MonoBehaviour
{
    // Start is called before the first frame update
    public static int enemyNum = 0;
    public int ballNum;
    public static int total_point;
    public GameObject WonPanel;
    public GameObject firstStar;
    public GameObject secondStar;
    public GameObject thirdStar;
    public int puan2,puan3;
    public Text pointText;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isLevelCompleted();
        
    }
    void isLevelCompleted(){
        if(enemyNum <= 0){
            
            StartCoroutine(open_stars());
        }else if(ballNum <= 0 ){
            
        }
    }
    IEnumerator open_stars(){
        
        pointText.text = (total_point + (ballNum*500)).ToString(); 
        yield return new WaitForSeconds(3.5f);
        WonPanel.SetActive(true);
        firstStar.SetActive(true);

        if((total_point + (ballNum*500)) >= puan2){
            yield return new WaitForSeconds(1);
            secondStar.SetActive(true);

        }if((total_point + (ballNum*500)) >= puan3){
            yield return new WaitForSeconds(1);
            thirdStar.SetActive(true);
        }
    }
    public void next_level(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }
}
