using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battery : MonoBehaviour
{

    PlayerMovement players;

    private void Start()
    {
        players =  FindObjectOfType<PlayerMovement>();

    }

    private void Update()
    {
  
    }





    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {

            Destroy(gameObject);
            players.addBattery();

        }
    }


}

