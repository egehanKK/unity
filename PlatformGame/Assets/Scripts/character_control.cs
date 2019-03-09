using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class character_control : MonoBehaviour {
    // Start is called before the first frame update
    float horizontal;
    public float hiz;
    public Animator animator;
    public int coinNumber = 0;
    public Text text_coin_number;
    public Text play_again_text_coin_number;
    public GameObject Panel_play_again;
    public static bool didGameStart = false;
    public GameObject Panel_start_game;
    public AudioSource coinSound;
    public int whichLevel = 1;

    

    void Start () {
        didGameStart = false;

    }

    // Update is called once per frame
    void Update () {
        //Time.deltaTime = 2; frame arası kaç sn

    }
    void FixedUpdate () {

        if(didGameStart == false){
            return;
        }

        //Time.fixedDeltaTime = 2;
        //horizontal = Input.GetAxis ("Horizontal");
        // -1 1 aralığında değişiyor sol(a) sağ(d)
        bool isRunning = false;
        if (horizontal != 0) {
            isRunning = true;
            animator.speed = Mathf.Abs (horizontal);

        } else {
            animator.speed = 1;
        }
        animator.SetBool ("isRunning", isRunning);
        transform.position += new Vector3 (horizontal * hiz * Time.deltaTime, 0, 0);

        changeDirection ();
        didFall();

    }
    void didFall(){
        if(transform.position.y < -5f){
            die();
        }
    }

    void changeDirection () {
        if (horizontal > 0) {
            transform.localScale = new Vector3 (1, 1, 1);
        } else if (horizontal < 0) {
            transform.localScale = new Vector3 (-1, 1, 1);
        }
    }

    void OnTriggerEnter2D (Collider2D hitted_object) {
        if (hitted_object.tag == "coins") {
            coinNumber ++;
            text_coin_number.text = coinNumber.ToString(); 
            Destroy(hitted_object.gameObject);
            coinSound.Play();
            
        }else if (hitted_object.tag == "trap")
        {
            
            die();
    
        }else if(hitted_object.tag == "gate"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            if(PlayerPrefs.GetInt("level")<whichLevel){
                    PlayerPrefs.SetInt("level",whichLevel);
            }
            
        }
    }
    void die(){
        Debug.Log("You died");
        Destroy(gameObject); 
        Panel_play_again.SetActive(true); 
        play_again_text_coin_number.text=coinNumber.ToString();      
    }
    public void startGame(){
        didGameStart = true;
        Panel_start_game.SetActive(false);

    }
    public void Move(int amount){
        horizontal = amount;
    }
    

}