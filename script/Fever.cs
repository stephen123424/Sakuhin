using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fever : MonoBehaviour
{
    [SerializeField] GameObject lefthand;
    [SerializeField] GameObject lefthandfront;
    [SerializeField] GameObject lefthandfinger;
    [SerializeField] GameObject lefthandcillnder;
    [SerializeField] GameObject lefthandfinger1;
    [SerializeField] GameObject lefthandfinger2;
    public SimpleHealthBar feverBar;
    public float current = 100, max = 100;
    public GameObject control;
    gamesession Gamesession;
    public bool pickedup =false;
    public bool timeup = false;
    // Start is called before the first frame update
    void Start()
    {

        Gamesession = control.GetComponent<gamesession>();
        
        
        feverBar.UpdateBar(current, max);
    }

    // Update is called once per frame
    void Update()
    {

        if(current >=100)
        {
            current = 100;
        }
        if (pickedup == true)
        {
            current=current-0.04f;
            
        }
        if(current <=0)
        {
            pickedup = false;
            timeup = true;
            foreach (Transform child in lefthand.transform)
            {
                if(child.tag== "caught")
                {
                    GameObject.Destroy(child.gameObject);
                }
                
            }
            foreach (Transform child in lefthandfront.transform)
            {
                if (child.tag == "caught")
                {
                    GameObject.Destroy(child.gameObject);
                }

            }
            foreach (Transform child in lefthandfinger.transform)
            {
                if (child.tag == "caught")
                {
                    GameObject.Destroy(child.gameObject);
                }

            }
            foreach (Transform child in lefthandfinger1.transform)
            {
                if (child.tag == "caught")
                {
                    GameObject.Destroy(child.gameObject);
                }

            }
            foreach (Transform child in lefthandfinger2.transform)
            {
                if (child.tag == "caught")
                {
                    GameObject.Destroy(child.gameObject);
                }

            }
            foreach (Transform child in lefthandcillnder.transform)
            {
                if (child.tag == "caught")
                {
                    GameObject.Destroy(child.gameObject);
                }

            }
            FindObjectOfType<gamesession>().resetcombo();
            Gamesession.dontshowFever();
        }
        feverBar.UpdateBar(current, max);
    }
    public void addtime(float time)
    {
        
        current =current + time;
        pickedup = true;
        
    }
}
