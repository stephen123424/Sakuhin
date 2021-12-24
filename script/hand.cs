using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour
{
    public GameObject hook;
    public GameObject hookholder;
    public float hooktravelspeed;
    public float playertravelspeed;
    public bool hooked;
    public static bool handfired;
    public GameObject hookedobj;
    public float maxdistance;
    private float currentdistance;

    private void Update()
    {
        if(Input.GetKey(KeyCode.O)&& handfired==false)
        {
            handfired = true;
            hooked = false;
        }
        if(handfired == true && hooked == false)
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hooktravelspeed);
            currentdistance = Vector3.Distance(transform.position, hook.transform.position);

            if(currentdistance >= maxdistance)
            {
                returnhook();
            }
        }
        if(hooked == true && handfired == true)
        {
            hook.transform.parent = hookedobj.transform;
            transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playertravelspeed);
            float distancetohook = Vector3.Distance(transform.position, hook.transform.position);
            

            
            if(distancetohook < 1)
            {
                //StartCoroutine(delay());
                returnhook();
                
            }
            
        }
        else
        {
            hook.transform.parent = hookholder.transform;
        }
    }



    private void returnhook()
    {
        hook.transform.rotation = hookholder.transform.rotation;
        hook.transform.position = hookholder.transform.position;
        handfired = false;
        hooked = false;
    }
 
}
