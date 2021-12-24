using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class batterystar : MonoBehaviour
{
    PlayerMovement player;
    [SerializeField] Texture fullstar;
    RawImage star;
    int gotbattery;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        star = GetComponent<RawImage>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        gotbattery = player.isBatteryTaken;
        
        if (gotbattery > 1)
        {
            star.texture = fullstar;
            
        }
        else return;
    }
}
