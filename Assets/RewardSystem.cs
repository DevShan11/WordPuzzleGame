using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordConnect;

public class RewardSystem : MonoBehaviour
{
    public GameController gameController;
    public CollectingCoins collectingCoins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiftPopUpReward()
    {
        StartCoroutine(delay());
        collectingCoins.CollectionCoins();
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(3);
        gameController.AddCoins(600);
    }
}
