using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCont : MonoBehaviour
{
    public Text texxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Kill") >= 3)
        {
            texxt.text = "열쇠가 피를 머금었다.";            
        }
        
    }
}
