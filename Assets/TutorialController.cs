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
    public GameObject RocketBtn;
   
    public bool isTouch;
    public bool isTutorialShow;
    // Start is called before the first frame update
   public void ShowButtons()
    {
       

        if (PlayerPrefs.GetInt("Tutorial") < 1)
        {
            tutorialHintBtn.SetActive(false);
            tutorialShuffleBtn.SetActive(false);
            adRewardBtn.SetActive(false);
            tutorialExtraWordBtn.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Tutorial") == 1)
        {
            tutorialHintBtn.SetActive(true);
            tutorialShuffleBtn.SetActive(true);
            adRewardBtn.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Tutorial") == 2)
        {
            tutorialHintBtn.SetActive(true);
            tutorialShuffleBtn.SetActive(true);
            adRewardBtn.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Tutorial") >= 4 && PlayerPrefs.GetInt("Tutorial") < 5 )
        {
            tutorialHintBtn.SetActive(true);
            tutorialShuffleBtn.SetActive(true);
            adRewardBtn.SetActive(true);
            tutorialExtraWordBtn.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Tutorial") >= 5)
        {
            tutorialHintBtn.SetActive(true);
            tutorialShuffleBtn.SetActive(true);
            adRewardBtn.SetActive(true);
            tutorialExtraWordBtn.SetActive(true);
            RocketBtn.SetActive(true);
        }
      
        

    }
    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("Tutorial"));
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void WonTutorialStop()
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
         PlayerPrefs.SetInt("Tutorial", 2);
         PlayerPrefs.Save();
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


   /* public void ShuffleBtnTutorialPlay()
    {   tutorialPanelBG.SetActive(true);
        
        tutorialShuffleBtn.SetActive(true);
      
    }*/


    public void Shuffle_Hint_TutorialPlay()
    {
        StartCoroutine(ShuffleHintDelay() );

    }
    public void Shuffle_Hint_TutorialStop()
    {
        tutorialPanelBG.SetActive(false);
        shuffleHintTutorialPanel.SetActive(false);
        // StartCoroutine(ExtraWordTuturialDelay());
        if (PlayerPrefs.GetInt("Tutorial") <3)
        {
            PlayerPrefs.SetInt("Tutorial", 3);
            PlayerPrefs.Save();
        }
        


    }
    public void ExtraWordTutorialPlay()
    {
        //StartCoroutine(ExtraWordTuturialDelay());
        tutorialPanelBG.SetActive(true);
        tutorialExtraWordBtn.SetActive(true);
        extraWordtutorial.SetActive(true);
       //adRewardBtn.SetActive(true);
       // MultiHintBtn.SetActive(true);
    }

    public void AdrewardButton()
    {
        StartCoroutine(AdrewrdButtonDelay());
        PlayerPrefs.SetInt("Tutorial", 4);
        PlayerPrefs.Save();
    }

    public void MultiHintButton()
    {
      
        RocketBtn.SetActive(true);

       /* PlayerPrefs.SetInt("Tutorial", 6);
        PlayerPrefs.Save();*/
    }

    public void ExtraWordTutorialStop()
    {
        tutorialPanelBG.SetActive(false);
        extraWordtutorial.SetActive(false);
       PlayerPrefs.SetInt("Tutorial", 5);
        PlayerPrefs.Save();
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

   /* IEnumerator ExtraWordTuturialDelay()
    {
        yield return new WaitForSeconds(2f);
        tutorialPanelBG.SetActive(true);
        tutorialExtraWordBtn.SetActive(true);
        extraWordtutorial.SetActive(true);
    }*/

    IEnumerator ShuffleHintDelay()
    {
        yield return new WaitForSeconds(.5f);
        // tutorialPanel.SetActive(true);
        tutorialPanelBG.SetActive(true);
        shuffleHintTutorialPanel.SetActive(true);
        tutorialHintBtn.SetActive(true);
        tutorialShuffleBtn.SetActive(true);
    }

    IEnumerator AdrewrdButtonDelay()
    {
        yield return new WaitForSeconds(.5f);
        adRewardBtn.SetActive(true);
    }



}
