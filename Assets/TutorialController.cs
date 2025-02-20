using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public GameObject tutorialPanelBG;
    public GameObject shuffleHintTutorialPanel;
    public GameObject tutorialsLine;
    public GameObject nowTutorialLine;
    public GameObject extraWordtutorial;
    public GameObject tutorialExtraWordBtn;
    public GameObject tutorialShuffleBtn;
    public GameObject tutorialHintBtn;
    public GameObject adRewardBtn;
    public GameObject MultiHintBtn;
   
    public bool isTouch;
    public bool isTutorialShow;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Tutorial") >0) 
        {
            tutorialShuffleBtn.SetActive(true);
            tutorialHintBtn.SetActive(true);
           // tutorialExtraWordBtn.SetActive(true);
}
        else
        {
            tutorialShuffleBtn.SetActive(false);
            tutorialHintBtn.SetActive(false);
            tutorialExtraWordBtn.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TutorialStop()
    {
        tutorialPanelBG.SetActive(false);
        tutorialsLine.SetActive(false);
       /* PlayerPrefs.SetInt("Tutorial", 1);
        PlayerPrefs.Save();*/
    }

    public void NowTutorialStop()
    {
        tutorialPanelBG.SetActive(false);
        nowTutorialLine.SetActive(false);
        /* PlayerPrefs.SetInt("Tutorial", 1);
         PlayerPrefs.Save();*/
    }




    public void Won_Tutorial() 
    {
        
            StartCoroutine(TuturialDelay());
            //isTutorialShow = true;
    }

    public void Now_Tutorial()
    {

        StartCoroutine(NowTuturialDelay());
        //isTutorialShow = true;
    }


    public void ShuffleBtnTutorialPlay()
    {   tutorialPanelBG.SetActive(true);
        
        tutorialShuffleBtn.SetActive(true);
      
    }


    public void Shuffle_Hint_TutorialPlay()
    {
        //  tutorialPanel.SetActive(true);
        tutorialPanelBG.SetActive(true);
        shuffleHintTutorialPanel.SetActive(true);
        tutorialHintBtn.SetActive(true);
        tutorialShuffleBtn.SetActive(true);

    }
    public void Shuffle_Hint_TutorialStop()
    {
        tutorialPanelBG.SetActive(false);
        shuffleHintTutorialPanel.SetActive(false);
        // StartCoroutine(ExtraWordTuturialDelay());
        PlayerPrefs.SetInt("Tutorial", 2);
        PlayerPrefs.Save();


    }
    public void ExtraWordTutorialPlay()
    {
        // StartCoroutine(ExtraWordTuturialDelay());
        tutorialPanelBG.SetActive(true);
        tutorialExtraWordBtn.SetActive(true);
        extraWordtutorial.SetActive(true);
        adRewardBtn.SetActive(true);
        MultiHintBtn.SetActive(true);

    }

        public void ExtraWordTutorialStop()
    {
        tutorialPanelBG.SetActive(false);
        extraWordtutorial.SetActive(false);
        PlayerPrefs.SetInt("Tutorial", 3);
        PlayerPrefs.Save();
    }

    public void HintBtnTutorialPlay()
    {
        /*if (PlayerPrefs.GetInt("Tutorial") ==1)
        {*/

      //  tutorialPanelBG.SetActive(true);
      //  tutorialHintBtn.SetActive(true);
       // tutorialHintHand.SetActive(true);
      //  }
    }

    public void ShuffleBtnTutorialStop()
    {
        /*tutorialPanelBG.SetActive(false);
        tutorialShuffleBtn.SetActive(true);
        tutorialShuffleHand.SetActive(false);*/
    }

    public void HintBtnTutorialStop()
    {
        tutorialPanelBG.SetActive(false);
        tutorialHintBtn.SetActive(true);
       

        
    }




    IEnumerator TuturialDelay() 
    {
        yield return new WaitForSeconds(1f); 
        tutorialPanelBG.SetActive(true);
        tutorialsLine.SetActive(true); 
    }

    IEnumerator NowTuturialDelay()
    {
        yield return new WaitForSeconds(.5f);
        tutorialPanelBG.SetActive(true);
        nowTutorialLine.SetActive(true);
    }

    IEnumerator ExtraWordTuturialDelay()
    {
        yield return new WaitForSeconds(2f);
        tutorialPanelBG.SetActive(true);
        tutorialExtraWordBtn.SetActive(true);
        extraWordtutorial.SetActive(true);
    }



}
