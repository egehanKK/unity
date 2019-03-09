using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeBackgroundColor : MonoBehaviour
{
    // Start is called before the first frame update
    public Color[] colors;
    Color first;
    Color second;
    int fs_color;
    public Material floorMaterial;
    void Start()
    {
        fs_color = Random.Range(0,colors.Length);
        floorMaterial.color = colors[fs_color];
        Camera.main.backgroundColor = colors[fs_color];
        second = colors[secondColor()];
    }

    int secondColor(){
        int snd_color;
        if(colors.Length <= 1){
            snd_color = fs_color;
        }
        snd_color = Random.Range(0,colors.Length);
        while(snd_color == fs_color){
            snd_color = Random.Range(0,colors.Length);
        }
        return snd_color;
        
    }

    // Update is called once per frame
    void Update()
    {
        Color colorDif = floorMaterial.color - second;
        if(Mathf.Abs(colorDif.r)  + Mathf.Abs(colorDif.g) +Mathf.Abs(colorDif.b) <   0.2f){
            second = colors[secondColor()];
        }
        floorMaterial.color = Color.Lerp(floorMaterial.color,second,0.003f);
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor,second,0.0009f);
        
    }
}
