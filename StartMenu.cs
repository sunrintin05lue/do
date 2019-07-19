using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartM()
    {
        PlayerPrefs.SetInt("Kill", 0);
        PlayerPrefs.SetInt("MapNum", 1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("MapNum"));
    }
    public void ExitExit()
    {

        Application.Quit();
    }
}
