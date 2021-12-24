using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameses;
    [SerializeField] Transform cattar;
    [SerializeField] Transform target;
    [SerializeField] float turnSpeed = 5f;
    [SerializeField] float senseRange = 10f;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    PlayerMovement script;
    gamesession Gamesession;

    private void Start()
    {
        script = player.GetComponent<PlayerMovement>();
        Gamesession = gameses.GetComponent<gamesession>();
    }
    private void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget <= senseRange)
        {
            isProvoked = true;
            if (isProvoked)
            {
                
                if (script.cathat == true)
                {

                    sitOnplayer();

                }
                else
                {
                    FaceTarget();
                }


            }
        }

    }



    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, senseRange);
    }

    public void sitOnplayer()
    {
        Vector3 sit = new Vector3(target.position.x, target.position.y , target.position.z);
        transform.LookAt(cattar);
        transform.position = sit;
        FindObjectOfType<gamesession>().showclaws();
    }
}
