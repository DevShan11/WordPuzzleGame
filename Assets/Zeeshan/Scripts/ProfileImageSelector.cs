using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileImageSelector : MonoBehaviour
{
    public Image currentProfileImage; // The current profile picture
    public Image mainProfileImage;
    public Button confirmButton;      // The confirm button
    public Image[] selectableImages;  // Array of selectable images
    public string playerPrefKey = "ProfileImage"; // Key for saving the selected profile image

    private Sprite selectedSprite;    // Temporarily stores the selected sprite

    public TMP_InputField nameInput;
    public TextMeshProUGUI textPanel;

    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("PlayerName"));

        SetName();

        // Load saved profile image on startup
        LoadProfileImage();

        // Add listeners to selectable images
        foreach (Image img in selectableImages)
        {
            img.GetComponent<Button>().onClick.AddListener(() => OnImageSelected(img));
        }

        // Add listener to confirm button
        confirmButton.onClick.AddListener(OnConfirm);
    }

    // Triggered when an image is selected
    private void OnImageSelected(Image selectedImage)
    {
        selectedSprite = selectedImage.sprite;
        currentProfileImage.sprite = selectedSprite;
    }

    // Triggered when confirm button is clicked
    private void OnConfirm()
    {
        PlayerPrefs.SetString("PlayerName",nameInput.text);
        PlayerPrefs.Save();
        if (selectedSprite != null)
        {
            // Save the selected image permanently
            SaveProfileImage(selectedSprite);
        }
        else
        {
            Debug.Log("No image selected.");
        }

        SetName();
    }

    // Saves the profile image (using PlayerPrefs)
    private void SaveProfileImage(Sprite sprite)
    {

        // Here we store the name of the sprite (or any unique identifier) in PlayerPrefs
        PlayerPrefs.SetString(playerPrefKey, sprite.name);
        PlayerPrefs.Save();
        mainProfileImage.sprite = currentProfileImage.sprite;
        Debug.Log("Profile image saved.");
    }

    // Loads the saved profile image from PlayerPrefs
    private void LoadProfileImage()
    {
        // Check if there is a saved profile image in PlayerPrefs
        if (PlayerPrefs.HasKey(playerPrefKey))
        {
            string savedImageName = PlayerPrefs.GetString(playerPrefKey);
            foreach (Image img in selectableImages)
            {
                if (img.sprite.name == savedImageName)
                {
                    // Set the current profile image to the saved sprite
                    currentProfileImage.sprite = img.sprite;
                    mainProfileImage.sprite = img.sprite;
                    selectedSprite = img.sprite;
                    

                    break;
                }
            }
        }
        else
        {
            Debug.Log("No saved profile image.");
        }
    }

    private void SetName()
    {
        if (PlayerPrefs.GetString("PlayerName") == string.Empty)
        {
            nameInput.text = "Player001";
        }
        else
        {

            nameInput.text = PlayerPrefs.GetString("PlayerName");
        }
        // nameInput.text = PlayerPrefs.GetString("PlayerName");
    }
}
