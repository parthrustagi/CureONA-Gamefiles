using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
	//[SerializeField]AudioController sw;
    bool PlayerDead = false;
    public GameObject InitialPlayer;
    public GameObject PlayerToSwitch;
    //public Vector2 InitialPosition;
    

    public void Update()
    {
        if (PlayerDead)
        {
			
            Instantiate(PlayerToSwitch, gameObject.transform.position, Quaternion.identity);
            PlayerDead = false;
        }

    }

    public void DoSwitch()
    {
		//sw.Play();
        PlayerDead = true;
		
    }
    
}
