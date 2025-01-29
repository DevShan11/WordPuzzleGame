using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordConnect;

public class Tutorial : MonoBehaviour
{
    public UIController uiController;
    // Start is called before the first frame update
    void Start()
    {
        uiController.OnMainScreenPlayClicked();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
