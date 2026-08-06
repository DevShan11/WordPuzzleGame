using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateUs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenLink()
    {
        PlayerPrefs.SetInt("Israted", 1);
        Application.OpenURL("https://www.google.com/search?gs_ssp=eJzj4tTP1TcwMU02T1JgNGB0YPBiS8_PT89JBQBASQXT&client=opera-gx&q=google&sourceid=opera&ie=UTF-8&oe=UTF-8");
        gameObject.SetActive(false);
    }

}
