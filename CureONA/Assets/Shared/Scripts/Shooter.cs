using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Shooter : MonoBehaviour
{
   [SerializeField]float rateOfFire;
   [SerializeField]Projectile projectile;
   //[SerializeField]Transform hand;


   
   public WeaponReloader reloader;

   float nextFireAllowed;
   public bool canFire;
   public Transform muzzle;

    public void Equip()
    {
		//transform.SetParent(hand);
    }
	
	
	void Awake(){
	   muzzle = transform.Find("Muzzle");
	   reloader = GetComponent<WeaponReloader>();
	   
	   
	}
	
	public void Reload() {
		if(reloader == null)
			return;
		reloader.Reload();
		
	}
	

   public virtual void Fire(){
	   
	   canFire = false;
	   
	   if(Time.time < nextFireAllowed)
		   return;
	   
	   if(reloader != null){
		   if(reloader.isReloading)
			   return;
		   
		   if(reloader.RoundsRemainingInClip == 0)
			   return;
		   
		   reloader.TakeFromClip(1);
		   
		   
		   
	   }
	   nextFireAllowed = Time.time + rateOfFire;
	   
	   Instantiate(projectile, muzzle.position, muzzle.rotation);
	   
	   print ("Firing!" + Time.time);
	   canFire = true;
	   
		   
   }
}
