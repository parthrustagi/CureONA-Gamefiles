using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        Invoke("Quit", 6.0f);    
    }

    public void Quit()
    {
        Application.Quit();
    }
}
