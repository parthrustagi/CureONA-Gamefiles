using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VirusSpawner : MonoBehaviour
{
    public GameObject Virus;
    public int numberOfVirus;
    private float range = 7.0f;
    float PosX;
    float PosZ;
    public VirusHit hit1;

    public void Start()
    {
        hit1 = GetComponent<VirusHit>();
        for (int i = 0; i <= numberOfVirus; i++)
        {
            Invoke("Spawner", 2.0f);
        }
    }

    /*private void Update()
    {
        if(hit1.Hit)
        {
            Invoke("Spawner", 2.0f);
        }
    }*/

    public void Spawner()
    {
        Instantiate(Virus, new Vector3 (Random.Range(38.8f, -82.3f), 1.73f, Random.Range(-2.86f, -16.83f)), Quaternion.identity);
        Instantiate(Virus, new Vector3 (Random.Range(-43.58f, 38.8f), 1.73f, Random.Range(-53.04f, -63.13f)), Quaternion.identity);
    }
}
