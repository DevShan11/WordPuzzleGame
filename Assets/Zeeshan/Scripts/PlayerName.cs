using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerName : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TextMeshProUGUI textPanel;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("PlayerName",nameInput.text);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
