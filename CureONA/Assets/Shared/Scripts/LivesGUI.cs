using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesGUI : MonoBehaviour
{
	public int lives;
	public Text LivesText;
	public Player playerlife;
	void Start(){
		playerlife = GameObject.Find("Player").GetComponent<Player>();
	}
	

    // Update is called once per frame
    void Update()
    {
		lives = playerlife.PlayerLives;
       LivesText.text = "                 " + lives.ToString();
	  
    }
}
