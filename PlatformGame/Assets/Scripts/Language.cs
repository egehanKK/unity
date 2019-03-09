using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    // Start is called before the first frame update

    public string tr;
    public string eng;
    public string fr;
    public string deu;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        writeAccLang();
        
    }

    // Update is called once per frame
   void writeAccLang(){
       if(Application.systemLanguage == SystemLanguage.Turkish){
           text.text= tr;

       }else if(Application.systemLanguage == SystemLanguage.French){
           text.text= fr;
       }
       else if(Application.systemLanguage == SystemLanguage.German){
           text.text= deu;
       }else{
           text.text = eng;
       }
   }
}
