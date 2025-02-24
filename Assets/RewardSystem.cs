using BBG.MobileTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordConnect;

public class RewardSystem : MonoBehaviour
{
    public GameController gameController;
    public CollectingCoins collectingCoins;
    public static RewardSystem instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }



    public void GiftPopUpReward()
    {
        AdsManager.Instance.ShowRewardedAd();
    }
    public void GiveCoins()
    {
        StartCoroutine(delay());
        collectingCoins.CollectionCoins();
        //gameController.AddCoins(80);
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(3);
        gameController.AddCoins(80);
    }

    public void InappCoinGift(int coins)
    {
        //gameController.AddCoins(coins);
        collectingCoins.CollectionCoins();
    }

    public void MarsBundle()
    {
        int temp = PlayerPrefs.GetInt("HintsCount");
        temp += 20;
        PlayerPrefs.SetInt("HintsCount", temp);
        gameController.HintsText.text = PlayerPrefs.GetInt("HintsCount").ToString();
        gameController.HintsText.gameObject.SetActive(true);
        int Multitemp = PlayerPrefs.GetInt("MultiHintsCount");
        Multitemp += 20;
        PlayerPrefs.SetInt("MultiHintsCount", Multitemp);
        gameController.MultiHintsText.text = PlayerPrefs.GetInt("MultiHintsCount").ToString();
        gameController.MultiHintsText.gameObject.SetActive(true);
        gameController.AddCoins(5000);
        collectingCoins.CollectionCoins();
    }

    public void RemoveAds()
    {
        PlayerPrefs.SetInt("ADSUNLOCK", 1);
        int temp = PlayerPrefs.GetInt("HintsCount");
        temp += 5;
        PlayerPrefs.SetInt("HintsCount", temp);
        gameController.HintsText.text = PlayerPrefs.GetInt("HintsCount").ToString();
        gameController.HintsText.gameObject.SetActive(true);
        int Multitemp = PlayerPrefs.GetInt("MultiHintsCount");
        Multitemp += 5;
        PlayerPrefs.SetInt("MultiHintsCount", Multitemp);
        gameController.MultiHintsText.text = PlayerPrefs.GetInt("MultiHintsCount").ToString();
        gameController.MultiHintsText.gameObject.SetActive(true);
        gameController.AddCoins(1000);
        collectingCoins.CollectionCoins();
    }
    public void RemoveAdsOnly()
    {
        PlayerPrefs.SetInt("ADSUNLOCK", 1);
    }


}
