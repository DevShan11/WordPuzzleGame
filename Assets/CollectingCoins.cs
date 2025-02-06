using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using System;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;




public class CollectingCoins : MonoBehaviour
{

    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform coinsParent;
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private int coinAmount;
    [SerializeField] private Transform endPosition;
    [SerializeField] private Text _coinText;
    [SerializeField] private float duration;
    [SerializeField] private float  minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    List<GameObject> coins = new List<GameObject>();

    private Tween coinReactionTween;

    private int coin;
    // Start is called before the first frame update
    void Start()
    {

        
        
    }
   
    public async void CollectionCoins()
    {

        //Reset 
        SetCoin(0);
        for (int i = 0; i < coins.Count; i++)
        {
            Destroy(coins[i]);
        }
        coins.Clear();

        // Spawn the coin to a specific location with random value

        for (int i = 0; i < coinAmount; i++)
        {
            GameObject coinInstance = Instantiate(coinPrefab, coinsParent);
            float xPosition = spawnLocation.position.x + UnityEngine.Random.Range(minX, maxX);
            float yPosition = spawnLocation.position.y + UnityEngine.Random.Range(minY, maxY);

            coinInstance.transform.position = new Vector3(xPosition, yPosition);
            coins.Add(coinInstance);
        }
        await UniTask.Delay(TimeSpan.FromSeconds(1f));

        //await unitas.Delay(TimeSpan.FromSeconds(1f));

        // Move all the coins to the coin label


        await MoveCoinTask();
    }

    private void SetCoin(int value)
    {
      /*  coin = value;
        _coinText.text = coin.ToString();*/
    }

    private async UniTask MoveCoinTask()
    {
        List<UniTask> moveCoinTask = new List<UniTask>();
        for (int i = 0; i < coins.Count; i++)
        {
          moveCoinTask.Add(  MoveCoinTask(i));
            await UniTask.Delay(TimeSpan.FromSeconds(0.05f));
        }
     
    }

    private async UniTask MoveCoinTask(int i)
    {
       await coins[i].transform.DOMove(endPosition.position, duration).SetEase(Ease.InBack).ToUniTask();
        ReactToCollectionCoin();
        SetCoin(coin + 1);
    }

    private async UniTask ReactToCollectionCoin()
    {
        if (coinReactionTween == null) 
        {
       coinReactionTween =  endPosition.DOPunchScale(new Vector3(0.5f,0.5f,0.5f),0.1f).SetEase(Ease.InOutElastic);
            await coinReactionTween.ToUniTask();
            coinReactionTween = null;
        }
    }

  

    // Update is called once per frame
    public void Button()
    {
        CollectionCoins();
    }
}
