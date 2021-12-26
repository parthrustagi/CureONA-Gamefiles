using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Application.LoadLevel("Scene_0");
    }
    
    public void QuitGame()
    {
        
        Application.Quit();
    }
}
