using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordConnect;

public class RewardSystem : MonoBehaviour
{
    public GameController gameController;
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
        gameController.AddCoins(600);
    }
}
