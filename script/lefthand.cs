using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lefthand : MonoBehaviour
{
    [SerializeField] GameObject fever;
    Fever timeups;

    float x = 0, z = 0, y = 0;
    float smooth = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        timeups = fever.GetComponent<Fever>();
    }

    // Update is called once per frame
    void Update()
    {
        y++;
        x++;
        var target = Quaternion.Euler(x, y, z);
        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target,
                                       Time.deltaTime * smooth); ;
        if (timeups.timeup == true)
        {
            Destroy(gameObject);
        }

    }
}
