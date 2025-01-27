using UnityEngine;
using System;
using UnityEngine.UI;
public class DailySpinManager : MonoBehaviour
{
    private const string LastSpinKey = "LastSpinTime";
    private TimeSpan spinCooldown = TimeSpan.FromHours(24);

    public Button spinButton; // Assign your spin button GameObject in the Inspector
    public Button MainspinButton;
    public GameObject cooldownMessage; // Optional: Message to show when spin is unavailable
    public GameObject SpinWheelpanel;

    void Start()
    {
        CheckSpinAvailability();
        
    }

    public void TrySpin()
    {
        if (IsSpinAvailable())
        {
            // Spin the wheel
            Spin();

            // Save the current time as the last spin time
            PlayerPrefs.SetString(LastSpinKey, DateTime.UtcNow.ToString());
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("FirstTime", 1);
            // Update button state
            CheckSpinAvailability();
        }
        else
        {
            ShowCooldownMessage();
        }
    }

    private void CheckSpinAvailability()
    {
        if (IsSpinAvailable() || PlayerPrefs.GetInt("FirstTime",0)==0)
        {
            // Enable the spin button and hide the cooldown message
            spinButton.interactable = true;
            MainspinButton.interactable = true;
          //  if (cooldownMessage != null) cooldownMessage.SetActive(false);
        }
        else
        {
            // Disable the spin button and show the cooldown message
            MainspinButton.interactable = false;//
            spinButton.interactable = false;
          //  if (cooldownMessage != null) cooldownMessage.SetActive(true);
        }
    }

    private bool IsSpinAvailable()
    {
        if (PlayerPrefs.HasKey(LastSpinKey))
        {
            string lastSpinTimeStr = PlayerPrefs.GetString(LastSpinKey);
            if (DateTime.TryParse(lastSpinTimeStr, out DateTime lastSpinTime))
            {
                TimeSpan timeSinceLastSpin = DateTime.UtcNow - lastSpinTime;
                return timeSinceLastSpin >= spinCooldown;
            }
        }

        // If no record of the last spin exists, it's available
        return true;
    }

    private void Spin()
    {
        Debug.Log("Spinning the wheel...");
        // Your wheel spin logic here
    }

    private void ShowCooldownMessage()
    {
        Debug.Log("Spin is not available yet. Please try again after 24 hours.");
    }
}
