
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class SplashScreenManager : MonoBehaviour
{
    public Sprite[] BackgroundImages;
    public Image BGImage;
    public string[] quots;
    public TextMeshProUGUI quotText;
    void Start()
    {
     int BG_Index= Random.Range(0, BackgroundImages.Length);
        Sprite img = BackgroundImages[BG_Index];
        BGImage.sprite = img;  
    int quot_Index = Random.Range(0, quots.Length);
        quotText.text = quots[quot_Index];
    }

   
    void Update()
    {
        
    }
}
