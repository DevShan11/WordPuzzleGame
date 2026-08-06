using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{

    public Image Bar_Img;
    public float waitTime = 30.0f;
    bool OneTimeCheck;

    private void Update()
    {
        Bar_Img.fillAmount += 1.0f / waitTime * Time.deltaTime;


        if (Bar_Img.fillAmount == 1 && !OneTimeCheck)
        {
            SceneManager.LoadSceneAsync(1);
            //SceneManager.LoadSceneAsync("MainMenu");
            OneTimeCheck = true;
        }

    }

}
