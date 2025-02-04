
using UnityEngine;
using System.Collections.Generic;


public class CollectingCoins : MonoBehaviour
{

    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform coinsParent;
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private int coinAmount;
    [SerializeField] private float  minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    List<GameObject> coins = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

        
        
    }
   
    public void CollectionCoins()
    {

        //Reset 
        for (int i = 0; i < coins.Count; i++)
        {
            Destroy(coins[i]);
        }
        coins.Clear();

        // Spawn the coin to a specific location with random value

        for (int i = 0; i < coinAmount; i++)
        {
            GameObject coinInstance = Instantiate(coinPrefab, coinsParent);
            float xPosition = spawnLocation.position.x + Random.Range(minX, maxX);
            float yPosition = spawnLocation.position.y + Random.Range(minY, maxY);

            coinInstance.transform.position = new Vector3(xPosition, yPosition);
            coins.Add(coinInstance);
        }
    }

  

    // Update is called once per frame
    public void Button()
    {
        CollectionCoins();
    }
}
