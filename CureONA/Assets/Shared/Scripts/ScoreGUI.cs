using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGUI : MonoBehaviour
{
    public int score = -1;
	public Text ScoreText;

	public void ScoreIn(){
		score = score + 50;
	}
	public void ScoreInV(){
		score = score + 20;
	}
    void Update()
    {
        ScoreText.text = "        " + score.ToString();
	  
    }
}
