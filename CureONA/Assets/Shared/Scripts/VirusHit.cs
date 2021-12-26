using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusHit : MonoBehaviour
{
	[SerializeField]AudioController sound;
	private ScoreGUI points;
	private int ScLimit = 0;
    public bool Hit = false;
    public ScoreGUI score3;
    public GameObject Effect;

    public void Start()
    {
		points = GameObject.Find("Score").GetComponent<ScoreGUI>();
        score3 = GameObject.Find("Score").GetComponent<ScoreGUI>();
    }
    public void Update()
    {
        VirusDestroy();
		if(score3.score > 2500)
        {
            VirusHitTrue();
            Instantiate(Effect, transform.position, Quaternion.LookRotation(transform.position));
        }
    }

    public void VirusDestroy()
    {
        if (Hit)
        {
            Destroy(gameObject);
			sound.Play();
			if(ScLimit == 0){
			points.ScoreInV();
			ScLimit = 1; }
        }
		
    }

    public void VirusHitTrue()
    {
        Hit = true;
    }
}
