using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class AIExample : Player
{
    [SerializeField] AudioController sw;
    public enum WanderType { Random, Waypoint };
    public GameObject BloodEffect;
    public GameObject HealingEffect;
	private ScoreGUI points;
	private int ScLimit = 0;
    public Player fpsc;
    public WanderType wanderType = WanderType.Random;
    public int ZombieHealth = 100;
    public float wanderSpeed = 4f;
    public float chaseSpeed = 7f;
    public float attackSpeed = 0.5f;
    public float fov = 120f;
    public float viewDistance = 10f;
    public float wanderRadius = 7f;
    public float loseThreshold = 2f; //time untill we lose the player after stop detecting
    public Transform[] waypoints; //waypoints when wandertype is waypoint selected
    public float destroytime = 4f;
    float PosX;
    float PosZ;
    public ScoreGUI score2;

    private bool isAware = false;
    private bool isDetecting = false;
    private Vector3 wanderPoint;
    private NavMeshAgent agent;
    private Renderer renderr;
    private int waypointIndex = 0;
    public Animator animator;
    private float loseTimer = 0;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        renderr = GetComponent<Renderer>();
        animator = GetComponentInChildren<Animator>();
        wanderPoint = RandomWanderPoint();
		points = GameObject.Find("Score").GetComponent<ScoreGUI>();
        score2 = GameObject.Find("Score").GetComponent<ScoreGUI>();

    }

    public void Update()
    {
        if (ZombieHealth > 0)
        {
            if (isAware)
            {
                
                agent.SetDestination(fpsc.transform.position);
                animator.SetBool("Aware", true);
                agent.speed = chaseSpeed;
                if (isDetecting)
                {
                    loseTimer += Time.deltaTime;
                    if (loseTimer >= loseThreshold)
                    {
                        isAware = false;
                        loseTimer = 0;
                    }
                } 
            }
            else
            {
                Wander();
                animator.SetBool("Aware", false);
                agent.speed = wanderSpeed;
                
            }
            
            SearchForPlayer();
        }
        else if (ZombieHealth < -1)
        {	if(ScLimit == 0)
            {
			    points.ScoreIn();
			    ScLimit = 1;
			}
	        ZombieHealth = -1;
            agent.speed = 0;
            animator.SetBool("Die", true);
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            Invoke("Healing", 3.95f);
            Invoke("TimetoSwitch", 3.95f);
            Destroy(gameObject, destroytime);
			
        }
        if(score2.score > 2500)
        {
            ZombieHealth = -2;
        }
    }

    public void Healing()
    {
        sw.Play();
        Instantiate(HealingEffect, gameObject.transform.position, Quaternion.identity);
    }

    public void SearchForPlayer()
    {
        if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(fpsc.transform.position)) < fov / 2f)
        {
            if (Vector3.Distance(fpsc.transform.position, transform.position) < viewDistance)
            {
                RaycastHit hit;
                if (Physics.Linecast(transform.position, fpsc.transform.position, out hit, -1))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        OnAware();
                    }
                    else
                    {
                        isDetecting = false;
                    }
                }
                else
                {
                    isDetecting = false;
                }
            }
            else
            {
                isDetecting = false;
            }
        }
        else
        {
            isDetecting = false;
        }
    }

    public void OnAware()
    {
        isAware = true;
        isDetecting = true;
        loseTimer = 0;
    }

    public void Wander()
    {
        if (wanderType == WanderType.Random)
        {
            if (Vector3.Distance(transform.position, wanderPoint) < 2f)
            {
                wanderPoint = RandomWanderPoint();
            }
            else
            {
                agent.SetDestination(wanderPoint);
            }
        }
        else
        {
            if (waypoints.Length >= 2)
            {
                if (Vector3.Distance(waypoints[waypointIndex].position, transform.position) < 2f)
                {
                    if (waypointIndex == waypoints.Length - 1)
                    {
                        waypointIndex = 0;
                    }
                    else
                    {
                        waypointIndex++;
                    }
                }
                else
                {
                    agent.SetDestination(waypoints[waypointIndex].position);
                }
            }
            else
            {
                Debug.LogWarning("Please assign more than one waypoint to the AI" + gameObject.name);
            }
        }
    }

    public void OnHit(int damage)
    {
        ZombieHealth -= damage;
    }

    
    public Vector3 RandomWanderPoint()
    {

        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomPoint, out navHit, wanderRadius, -1);
        return new Vector3(navHit.position.x, transform.position.y, navHit.position.z);
    }

    public void OnCollisionStay(Collision collisioninfo)
    {
        if(collisioninfo.gameObject.CompareTag("Player"))
        {
            PosX = collisioninfo.gameObject.transform.position.x;
            PosZ = collisioninfo.gameObject.transform.position.z;
            animator.SetBool("Attack", true);
            agent.speed = attackSpeed;
            if (collisioninfo.gameObject.GetComponentInChildren<Animator>().GetBool("Died") == false)
            {
                if (this.gameObject.GetComponent<Animator>().GetBool("Die") == false)
                {
                    Instantiate(BloodEffect, new Vector3(PosX, 1.73f, PosZ), Quaternion.LookRotation(collisioninfo.gameObject.transform.position));
                }
            }
        }
    }

    public void OnCollisionExit(Collision collisionother)
    {
        animator.SetBool("Attack", false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponentInChildren<Animator>().GetBool("Died") == false)
            {
                if(this.gameObject.GetComponent<Animator>().GetBool("Die") == false)
                {
                    PlayerDamage(10);
                }
            }
        }
    }

    public void TimetoSwitch()
    {
        GetComponent<SwitchCharacter>().DoSwitch();
    }
}
