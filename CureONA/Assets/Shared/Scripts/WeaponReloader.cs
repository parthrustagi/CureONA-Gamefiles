
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReloader : MonoBehaviour
{
	[SerializeField]int maxAmmo;
	[SerializeField]float reloadTime;
	[SerializeField]int clipSize;
	[SerializeField]Container inventory;
	
	public int shotsFiredInClip;
	public bool isReloading;
	System.Guid containerItemId;
	
	public int RoundsRemainingInClip{
		get{
			return clipSize - shotsFiredInClip;
		}
		
	}
	
	public bool IsReloading{
		get{
			return isReloading;
		}
		
	}
	
	void Awake(){
		containerItemId = inventory.Add(this.name, maxAmmo);
	}
	public void Reload(){
		if(isReloading)
			return;
		
		isReloading = true;
		GameManager.Instance.Timer.Add(() => {
		ExecuteReload(inventory.TakeFromContainer(containerItemId, clipSize - RoundsRemainingInClip));
		}, reloadTime);
	}
	
	private void ExecuteReload(int amount){
		
		isReloading = false;
		shotsFiredInClip -= amount;
		
		
	}
	
public void TakeFromClip(int amount){
	shotsFiredInClip += amount;
}
}
