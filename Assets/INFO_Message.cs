using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class INFO_Message : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text message;
    public GameObject LocalMessage01;
    public GameObject LocalMessage02;
    public GameObject LocalMessage03;
    public GameObject LocalMessage04;
    public GameObject MessageOnLevelCompletion;
    void Start()
    {
        
    }
  /*  public void ShowLocal(string txt)
    {
        message.text = txt;
        LocalMessage.SetActive(true);
        Invoke(nameof(SwitchOff), 1);
    }*/
  /* public void SwitchOff()
    {
        LocalMessage01.gameObject.SetActive(false);
        LocalMessage02.gameObject.SetActive(false);
        LocalMessage03.gameObject.SetActive(false);
        LocalMessage04.gameObject.SetActive(false);
    }*/

    public void showInfoMessage(GameObject message )
    {
        message.SetActive(true);
        
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
