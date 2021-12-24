using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class bug : MonoBehaviour
{
    [SerializeField] int scoreValue = 500;
    [SerializeField] int catHatScoreValue = 1000;
    [SerializeField] Transform target;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] float senseRange = 7f;
    [SerializeField] float runRange = 3f;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] GameObject player;
    [SerializeField] GameObject count;
    [SerializeField] GameObject feverbar;
    [SerializeField] GameObject bug1;
    [SerializeField] Transform lefthand;



    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    bool isRunning = false;
    bool isCatched = false;
    int bugcount;
    
    NavMeshAgent navMashAgent;
    PlayerMovement script;
    gamesession Gamesession;
    Fever fever;
    private void Start()
    {
        navMashAgent = GetComponent<NavMeshAgent>();
        script = player.GetComponent<PlayerMovement>();
        Gamesession = count.GetComponent<gamesession>();
        fever = feverbar.GetComponent<Fever>();
        
        Count();
    }

    private void Count()
    {
        if (tag == "Bug")
        {

            Gamesession.countBug();
            bugcount++;
        }
    }
    private void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);



        if (distanceToTarget <= senseRange)
        {
            isProvoked = true;
            if (isProvoked)
            {
                FaceTarget();
            }
        }
        if(distanceToTarget <= runRange)
        {
            isProvoked = false;
            isRunning = true;
            if(isRunning)
            {
                runAway();
            }
        }
    }

    private void runAway()
    {
        Vector3 runaway = transform.position - target.position ;
        Vector3 newPos = transform.position + runaway;
        navMashAgent.SetDestination(newPos);
        
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (script.cathat == true)
            {
                int i = FindObjectOfType<gamesession>().getCombo();
                FindObjectOfType<gamesession>().AddtoScore(catHatScoreValue*(i+1));
                FindObjectOfType<gamesession>().decreaseBug(bugcount);
            }
            else
            {
                int i = FindObjectOfType<gamesession>().getCombo();
                FindObjectOfType<gamesession>().AddtoScore(scoreValue *(i+1));
                FindObjectOfType<gamesession>().decreaseBug(bugcount);
            }
            Gamesession.showFever();
            fever.addtime(100f);
            isCatched = true;
            FindObjectOfType<gamesession>().addcombo(1);
            
            var bugleft = Instantiate(bug1, lefthand.position, Quaternion.identity);
            bugleft.transform.parent = lefthand.transform;
            Destroy(gameObject);

        }
    }
    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, senseRange);
    }
}
