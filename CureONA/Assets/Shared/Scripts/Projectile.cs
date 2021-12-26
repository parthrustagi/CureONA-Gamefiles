using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField]float speed;
	[SerializeField]float timeToLive;
	[SerializeField]int Hitdamage;
    public GameObject BloodEffect;
    public GameObject Effect;
	
	void Start()
    {
		Destroy(gameObject, timeToLive);
		
	}
	void Update()
    {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            other.GetComponent<AIExample>().OnHit(Hitdamage);
            Instantiate(BloodEffect, other.gameObject.transform.position, Quaternion.LookRotation(other.gameObject.transform.position));
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Virus"))
        {
            other.GetComponent<VirusHit>().VirusHitTrue();
            Instantiate(Effect, other.gameObject.transform.position, Quaternion.LookRotation(other.gameObject.transform.position));
            Destroy(gameObject);
        }
    }
}
