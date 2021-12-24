using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookobj : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="hookable")
        {
           player.GetComponent<PlayerMovement>().hooked = true;
           player.GetComponent<PlayerMovement>().hookedobj = other.gameObject;
           
        }
    }
}
