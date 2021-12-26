using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScreenButton : MonoBehaviour
{
    void Update()
    {
        Invoke("Quit", 10.0f);
    }


    public void Quit()
    {
        Application.Quit();
    }
}
