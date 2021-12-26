using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider healthbar;
	Player playerhealth;
	void Start(){
	playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	void Upate(){
		
		healthbar.value = playerhealth.RetHealth();
	}
}
