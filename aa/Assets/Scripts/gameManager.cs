using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject circle;
    GameObject mainCircle;
    public Animator animator;
    public Text level;
    public Text one;
    public Text two;
    public Text three;
    public int circleNum;
    bool control = true;

    void Start()
    {
        
        PlayerPrefs.SetInt("levelNum",int.Parse(SceneManager.GetActiveScene().name));
        level.text = SceneManager.GetActiveScene().name;
        circle = GameObject.FindWithTag("circleTag");
        mainCircle = GameObject.FindWithTag("mainCircleTag");

        if(circleNum < 2){
            one.text = circleNum.ToString();
        }
        else if( circleNum < 3){
            one.text = circleNum.ToString();
            two.text = (circleNum-1).ToString();
        }else{
            one.text = circleNum.ToString();
            two.text = (circleNum-1).ToString();
            three.text = (circleNum -2).ToString();

        }
        
    }
    public void secondaryCircleText(){
        circleNum--;
        if(circleNum < 2){
            one.text = circleNum.ToString();
            two.text = "";
            three.text = "";

        }
        else if( circleNum < 3){
            one.text = circleNum.ToString();
            two.text = (circleNum-1).ToString();
            three.text = "";
        }else{
            one.text = circleNum.ToString();
            two.text = (circleNum-1).ToString();
            three.text = (circleNum -2).ToString();

        }
        if(circleNum == 0){
            StartCoroutine(newLevel());
        }

    }

    IEnumerator newLevel(){
        circle.GetComponent<spin>().enabled = false;
        mainCircle.GetComponent<MainCircle>().enabled = false;
        
        if(control && SceneManager.GetActiveScene().name != "10"){
            
            animator.SetTrigger("newLevel");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name)+1);
        }else{
            SceneManager.LoadScene("1");
        }
        

    }
    

    public void gameOver(){

        StartCoroutine(overMethod());

    }
    IEnumerator overMethod(){

        circle.GetComponent<spin>().enabled = false;
        mainCircle.GetComponent<MainCircle>().enabled = false;
        animator.SetTrigger("gameOver");
        control = false;
        yield return new WaitForSeconds(1);
        
        SceneManager.LoadScene("Main Menu");

    }

    
}
