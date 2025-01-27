using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class INFO_Message : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text message;
    public GameObject LocalMessage;
    public GameObject MessageOnLevelCompletion;
    void Start()
    {
        
    }
    public void ShowLocal(string txt)
    {
        message.text = txt;
        LocalMessage.SetActive(true);
        Invoke(nameof(SwitchOff), 1);
    }
    void SwitchOff()
    {
        LocalMessage.gameObject.SetActive(false);
    }
    public void Show_Message()
    {
        MessageOnLevelCompletion.SetActive(true);
    }
    public void Disable_Message()
    {
        MessageOnLevelCompletion.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
