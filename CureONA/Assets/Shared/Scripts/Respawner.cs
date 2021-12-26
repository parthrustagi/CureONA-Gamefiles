using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
  public void Despawn(GameObject go, float inseconds)
  {
	  go.SetActive(false);
	  GameManager.Instance.Timer.Add(() => 
      {
		  go.SetActive(true);
      }, inseconds);
  }  
}
