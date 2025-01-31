using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject tutorialsLine;
    public GameObject tutorialShuffleBtn;
    public GameObject tutorialShuffleHand;
    public GameObject tutorialHintBtn;
    public GameObject tutorialHintHand;
    public bool isTouch;
    public bool isTutorialShow;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Tutorial") >0) 
        {
            tutorialShuffleBtn.SetActive(true);
            tutorialHintBtn.SetActive(true);
            tutorialShuffleHand.SetActive(false);
            tutorialHintHand.SetActive(false);
}
        else
        {
            tutorialShuffleBtn.SetActive(false);
            tutorialHintBtn.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TutorialStop()
    {
        tutorialPanel.SetActive(false);
        tutorialsLine.SetActive(false);
       /* PlayerPrefs.SetInt("Tutorial", 1);
        PlayerPrefs.Save();*/
    }




    public void PlayTutorial() 
    {
        
            StartCoroutine(TuturialDelay());
            //isTutorialShow = true;
        
         
    }


    public void ShuffleBtnTutorialPlay()
    {   tutorialPanel.SetActive(true);
        tutorialShuffleBtn.SetActive(true);
        tutorialShuffleHand.SetActive(true);
    }

    public void HintBtnTutorialPlay()
    {
        if (PlayerPrefs.GetInt("Tutorial") ==0)
        {

        tutorialPanel.SetActive(true);
        tutorialHintBtn.SetActive(true);
        tutorialHintHand.SetActive(true);
        }
    }

    public void ShuffleBtnTutorialStop()
    {
        tutorialPanel.SetActive(false);
        tutorialShuffleBtn.SetActive(true);
        tutorialShuffleHand.SetActive(false);
    }

    public void HintBtnTutorialStop()
    {
        tutorialPanel.SetActive(false);
        tutorialHintBtn.SetActive(true);
        tutorialHintHand.SetActive(false);

        PlayerPrefs.SetInt("Tutorial", 1);
        PlayerPrefs.Save();
    }




    IEnumerator TuturialDelay() 
    {
        yield return new WaitForSeconds(1f); 
        tutorialPanel.SetActive(true);
        tutorialsLine.SetActive(true); 
    }
   
}
