using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThirdPersonCharacterControl : MonoBehaviour
{
    public float Speed;
    public float extraSpeed;
    bool buttonpressed = false;
    float y = 1;
    public SimpleHealthBar energybar;
    [SerializeField] public float current = 100;
    [SerializeField] public float max = 100;
    [SerializeField] Transform cat;
    [SerializeField] float accessCat = 1;
    float distanceToCat = Mathf.Infinity;
    public bool cathat = false;
    public bool gameOver = false;
    public float batTimer;
    public int isBatteryTaken = 0;
    Rigidbody rb;


    private void Start()
    {
        FindObjectOfType<level>();
        
        current = max;
        energybar.UpdateBar(current, max);
        rb = GetComponent<Rigidbody>();

    }
    private void Update ()
    {
        
        PlayerMovement();
        applyGravity();
        if (Input.GetKey(KeyCode.Space))
        {
            buttonpressed = true;
        }
        else
        {
            buttonpressed = false;
        }
        distanceToCat = Vector3.Distance(cat.position, transform.position);
        if (Input.GetKeyDown(KeyCode.U)&& distanceToCat<=accessCat)
        {
            
            cathat = !cathat;
            //FindObjectOfType<cat>().sitOnplayer();
        }

        if (current <= 0)
        {
            current = 0;
            gameover();
        }

        if (batTimer >= 0)
        {
            batTimer -= Time.deltaTime;
        }
        //print(current);
    }

    private void gameover()
    {
        FindObjectOfType<level>().retryScene();
    }

    private void applyGravity()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            Vector3 newpos = new Vector3(transform.position.x, transform.position.y + y, transform.position.z);

            rb.MovePosition(newpos);


            //transform.Translate(0, -y, 0);
            if(cathat == true)
            {
                current = current - 20;
            }
            else
            {
                current = current - 10;
            }
            
            energybar.UpdateBar(current, max);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 newpos = new Vector3(transform.position.x, transform.position.y - y, transform.position.z);

            rb.MovePosition(newpos);
            if (cathat == true)
            {
                current = current - 20;
            }
            else
            {
                current = current - 10;
            }
            energybar.UpdateBar(current, max);
        }
    }

    private void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (buttonpressed == true)
        {
            Vector3 playerMovement = new Vector3(hor, 0f, ver) * extraSpeed * Time.deltaTime;
            transform.Translate(playerMovement);
            if (cathat == true)
            {
                current = current - (10 * Time.deltaTime);
            }
            else
            {
                current = current - (5 * Time.deltaTime);
            }
            
            energybar.UpdateBar(current, max);
        }
        if(buttonpressed == false)
        {
            Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
            transform.Translate(playerMovement);
            if (cathat == true)
            {
                current = current - (2 * Time.deltaTime);
            }
            else
            {
                current = current - (1 * Time.deltaTime);
            }
            
            energybar.UpdateBar(current, max);
        }
       
    }

   public void addBattery()
    {
        if (batTimer <= 0)
        {
            current = current + 50;
            if (current >= 100)
            {
                current = 100;
                energybar.UpdateBar(current, max);
            }
            else
            {
                energybar.UpdateBar(current, max);
            }
            isBatteryTaken = isBatteryTaken + 1;
            batTimer = 0.5f;
        }

    }


}