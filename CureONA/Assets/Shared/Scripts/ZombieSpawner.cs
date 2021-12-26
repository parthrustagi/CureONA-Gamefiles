using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawner : MonoBehaviour
{
    int roundVirus=0;
    public GameObject Zombie;
    int numberOfZombies = 2;
    private float range = 7.0f;
    public ScoreGUI score2;
    public int i = 0;

    public void Start()
    {
        score2 = GameObject.Find("Score").GetComponent<ScoreGUI>();
    }

    void Update()
    {
        if(score2.score < 500 && roundVirus == 0)
        {
            roundVirus++;
            while (i < numberOfZombies)
            {
                Invoke("Spawner", 2.0f);
                i++;
            }
        }

        if(score2.score > 500 && roundVirus == 1)
        {
            roundVirus++;
            while (i <= numberOfZombies + 4)
            {
                Invoke("Spawner", 2.0f);
                i++;
            }
        }

        if (score2.score > 1200 && roundVirus == 2)
        {
            roundVirus++;
            while (i <= numberOfZombies + 8)
            {
                Invoke("Spawner", 2.0f);
                i++;
            }
        }

        if (score2.score > 2000 && roundVirus == 3)
        {
            roundVirus++;
            while (i <= numberOfZombies + 12)
            {
                Invoke("Spawner", 2.0f);
                i++;
            }
        }
    }

    public void Spawner()
    {
        Instantiate(Zombie, RandomNavMeshLocation(range), Quaternion.identity);
    }

    public Vector3 RandomNavMeshLocation (float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if(NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
