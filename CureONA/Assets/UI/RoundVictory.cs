using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RoundVictory : MonoBehaviour
{
	[SerializeField]AudioController victorysound;
    public int round = 1;
    public ScoreGUI score1;
    public Player player3;
    public GameObject RoundWinMenu1;
    public GameObject RoundWinMenu2;
    public GameObject RoundWinMenu3;
    public GameObject Wave1;
    public GameObject Wave2;
    public GameObject Wave3;
    public GameObject FinalVictory;
    public GameObject Celeration;

    void Start()
    {
        score1 = GameObject.Find("Score").GetComponent<ScoreGUI>();
        player3 = GameObject.Find("Player").GetComponent<Player>(); 
    }
    
    void Update()
    {
        if(score1.score == -1)
        {
            Wave1.SetActive(true);
            Time.timeScale = 0.2f;
            score1.score = 0;
            Invoke("Round1", 1.0f);
			
        }

        if(score1.score > 500  && round == 1)
        {
            round++;
            RoundWinMenu1.SetActive(true);
            
            Time.timeScale = 0.2f;
			victorysound.Play();
            Invoke("Round2", 0.5f);
        }

        if (score1.score > 1200 && round == 2)
        {
            RoundWinMenu2.SetActive(true);
            
            Time.timeScale = 0.2f;
            round++;
			victorysound.Play();
            Invoke("Round3", 0.5f);
            
        }

        if (score1.score > 2000 && round == 3)
        {
            RoundWinMenu3.SetActive(true);
            
            Time.timeScale = 0.2f;
            round++;
			victorysound.Play();
            Invoke("Round4", 1.0f);
        }

        if (score1.score > 2500 && round == 4)
        {
            Invoke("FinalEnding", 9.0f);
        }

        if (player3.Margya == true)
        {
            Invoke("GameEnd", 4.0f);
        }
    }

    void Round1()
    {
        Wave1.SetActive(false);
        Time.timeScale = 1f;
       
    }

    void Round2()
    {
        
        RoundWinMenu1.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void Round3()
    {
        RoundWinMenu2.SetActive(false);
        Time.timeScale = 1.0f;
  
    }

    void Round4()
    {
        RoundWinMenu3.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void FinalEnding()
    {
        SceneManager.LoadScene("Final");
    }

    void GameEnd()
    {
        SceneManager.LoadScene("GameOver");
    }
}
