using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class trash : MonoBehaviour
{
    [SerializeField] int scoreValue = 100;
    [SerializeField] int catHatScoreValue = 200;
    [SerializeField] Transform target;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] float senseRange = 5f;
    [SerializeField] GameObject player;
    [SerializeField] GameObject count;
    [SerializeField] GameObject feverbar;
    [SerializeField] GameObject trash11;
    [SerializeField] Transform lefthand;
    int trashcount;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    bool isCatched = false;
    PlayerMovement script;
    gamesession Gamesession;
    Fever fevers;
    private void Start()
    {
        script = player.GetComponent<PlayerMovement>();
        Gamesession = count.GetComponent<gamesession>();
        fevers = feverbar.GetComponent<Fever>();
        countT();
    }

    private void countT()
    {
        if(tag == "Trash")
        {
            
            Gamesession.countTrash();
            trashcount++;
        }
        
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

    if (distanceToTarget <= senseRange)
        {
            isProvoked = true;
            if(isProvoked)
            {
                FaceTarget();
            }
        }
        
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
            if(script.cathat == true)
            {
                int i = FindObjectOfType<gamesession>().getCombo();
                FindObjectOfType<gamesession>().AddtoScore(catHatScoreValue * (i + 1));
                FindObjectOfType<gamesession>().decreaseTrash(trashcount);
            }
            else
            {
                int i = FindObjectOfType<gamesession>().getCombo();
                FindObjectOfType<gamesession>().AddtoScore(scoreValue * (i + 1));
                FindObjectOfType<gamesession>().decreaseTrash(trashcount);
            }
            Gamesession.showFever();
            fevers.addtime(100f);
            isCatched = true;
            FindObjectOfType<gamesession>().addcombo(1);

            var bugleft = Instantiate(trash11, lefthand.position, Quaternion.identity);
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
