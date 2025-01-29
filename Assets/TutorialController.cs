using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject tutorialsLine;
    public GameObject tutorialShuffleBtn;
    public GameObject tutorialShuffleHand;
    public bool isTouch;
    public bool isTutorialShow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       


        
    }

    public void TutorialStop()
    {
        tutorialPanel.SetActive(false);
        tutorialsLine.SetActive(false);
        PlayerPrefs.SetInt("Tutorial", 1);
        PlayerPrefs.Save();
    }




    public void PlayTutorial() 
    {
        // pla Tutorial
        if (!isTouch)
        {
            StartCoroutine(TuturialDelay());
            //isTutorialShow = true;
        }
         
    }


    public void ShuffleBtnTutorialPlay()
    {
        tutorialShuffleBtn.SetActive(true);
        tutorialShuffleHand.SetActive(true);
    }




    IEnumerator TuturialDelay() 
    {
        yield return new WaitForSeconds(1f); 
        tutorialPanel.SetActive(true);
        tutorialsLine.SetActive(true); 
    }
   
}
