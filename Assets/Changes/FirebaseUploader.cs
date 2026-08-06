using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections.Generic;

public class FirebaseUploader : MonoBehaviour
{
    private DatabaseReference dbReference;
    public static FirebaseUploader instance;

    [Header("UI References")]
    public Transform contentPanel;  // Parent UI where player data will be displayed
    public GameObject playerUIPrefab; // Prefab containing Text + Image

    [Header("Player Images")]
    public Sprite[] playerImages; // Assign images in the Unity Inspector

    void Start()
    {
        instance = this;
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                FirebaseApp app = FirebaseApp.DefaultInstance;
                dbReference = FirebaseDatabase.DefaultInstance.RootReference;
                Debug.Log("🔥 Firebase Initialized!");
               // GenerateDummyData();
               

            }
            else
            {
                Debug.LogError("❌ Firebase Failed to Initialize: " + task.Result);
            }
        });
    }

    void GenerateDummyData()
    {
        List<PlayerData> dummyPlayers = new List<PlayerData>
        {
            new PlayerData("John Doe", 150, 2),
            new PlayerData("Jane Smith", 200, 1),
            new PlayerData("Alex Johnson", 250, 0),
            new PlayerData("Emma Brown", 300, 3),
            new PlayerData("Chris Green", 120, 5)
        };

        foreach (var player in dummyPlayers)
        {
            string playerID = dbReference.Child("Players").Push().Key; // Generate unique key
            string json = JsonUtility.ToJson(player);

            dbReference.Child("Players").Child(playerID).SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log($"✅ Dummy Data Added: {player.playerName} | Score: {player.score}");
                }
                else
                {
                    Debug.LogError("❌ Failed to Add Dummy Data: " + task.Exception);
                }
            });
        }
    }

    // ✅ Save Player Data (Including Selected Image Index)
    public void SavePlayerData(string playerName, int score, int selectedImageIndex)
    {
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogError("❌ Player Name is empty! Cannot save data.");
            return;
        }

        // Use the device's unique ID to prevent duplicate entries
        string deviceID = SystemInfo.deviceUniqueIdentifier;

        PlayerData playerData = new PlayerData(playerName, score, selectedImageIndex);
        string json = JsonUtility.ToJson(playerData);

        dbReference.Child("Players").Child(deviceID).SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log($"✅ Player Data Updated for {playerName} | Image Index: {selectedImageIndex}");
            }
            else
            {
                Debug.LogError("❌ Failed to Save Player Data: " + task.Exception);
            }
        });
    }

    // ✅ Load All Players & Display in UI
    public void LoadAllPlayersData()
    {
        dbReference.Child("Players").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted && task.Result.Exists)
            {
                DataSnapshot snapshot = task.Result;

                // Clear previous UI elements
                foreach (Transform child in contentPanel)
                {
                    Destroy(child.gameObject);
                }

                List<PlayerData> players = new List<PlayerData>();

                foreach (var player in snapshot.Children)
                {
                    string playerName = player.Child("playerName").Value.ToString();
                    int score = int.Parse(player.Child("score").Value.ToString());
                    int imageIndex = player.HasChild("selectedImageIndex") ? int.Parse(player.Child("selectedImageIndex").Value.ToString()) : 0;

                    players.Add(new PlayerData(playerName, score, imageIndex));
                }

                // Sort players by score (Descending Order)
                players.Sort((a, b) => b.score.CompareTo(a.score));

                // Display in UI
                foreach (var player in players)
                {
                    GameObject playerEntry = Instantiate(playerUIPrefab, contentPanel);
                    playerEntry.transform.Find("PlayerNameText").GetComponent<Text>().text = player.playerName;
                    playerEntry.transform.Find("ScoreText").GetComponent<Text>().text = $"{player.score}";

                    // Set Image if available
                    Image playerImage = playerEntry.transform.Find("PlayerImage").GetComponent<Image>();
                    if (playerImages != null && player.selectedImageIndex < playerImages.Length)
                    {
                        playerImage.sprite = playerImages[player.selectedImageIndex];
                    }

                    Debug.Log($"✅ Loaded: {player.playerName} - Score: {player.score} - ImageIndex: {player.selectedImageIndex}");
                }
            }
            else
            {
                Debug.LogError("❌ Failed to Load Players: " + task.Exception);
            }
        });
    }
    int imageindex;
    // ✅ Select Image & Save Player Data
    public void OnImageClicked(int index)
    {
        imageindex = index;
    }

    public void SaveUserData()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "Unknown");
        int playerScore = 121;
        SavePlayerData(playerName, playerScore, imageindex);
    }

    // ✅ Player Data Class
    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public int score;
        public int selectedImageIndex;

        public PlayerData(string name, int playerScore, int imageIndex)
        {
            playerName = name;
            score = playerScore;
            selectedImageIndex = imageIndex;
        }
    }
}
