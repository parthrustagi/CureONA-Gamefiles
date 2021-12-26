using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player1;
	public float pX;
	public float pY;
	public float pZ;
	
	void Update(){
		pX = Player1.transform.eulerAngles.x;
		pY = Player1.transform.eulerAngles.y;
		pZ = Player1.transform.eulerAngles.z;
		//transform.eulerAngles = new Vector3(pX-pX,pY,pZ-pZ);
		
	}
	
	
}
