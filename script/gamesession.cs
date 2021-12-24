using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamesession : MonoBehaviour
{
    
    int score;
    int remainingTrash;
    int remainingbug;
    level Level;
    [SerializeField] Canvas GGCanvas;
    [SerializeField] Canvas catclaw;
    [SerializeField] SimpleHealthBar fever;
    int combo;
    private void Awake()
    {
        combo = 0;
        score = 0;
        remainingTrash = 0;
        remainingbug = 0;
        GGCanvas.gameObject.SetActive(false);
        catclaw.enabled = false;
        fever.gameObject.SetActive(false);
        Level = FindObjectOfType<level>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //SetUpSingleton();
    }

    private void Update()
    {
        if (remainingTrash <= 0 && remainingbug <= 0)
        {

            //Level.welldoneScene();
            ShowWelldone();
        }
    }
    /*   private void SetUpSingleton()
       {
           int numberGameSession = FindObjectsOfType<gamesession>().Length;

           if (numberGameSession > 1)
           {
               Destroy(gameObject);
           }
           else
           {
               DontDestroyOnLoad(gameObject);
           }
       }*/
    public int GetScore()
    {
        return score;  
    }
    public void AddtoScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void countTrash()
    {
        remainingTrash++;
    }
    public int GetTrash()
    {
        return remainingTrash;
    }
    public void decreaseTrash(int trash)
    {
        remainingTrash -= trash;

    }
    public void decreaseBug(int bug)
    {
        remainingbug -= bug;

    }
    public void ShowWelldone()
    {
        GGCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
         Cursor.lockState = CursorLockMode.None;
         Cursor.visible = true;

    }
    public void showclaws()
    {
        catclaw.enabled = true;
    }
    public void countBug()
    {
        remainingbug++;
    }
    public int Getbug()
    {
        return remainingbug;
    }
    public void showFever()
    {
        
        fever.gameObject.SetActive(true);
        Debug.Log("YEET");
    }
    public void dontshowFever()
    {
        fever.gameObject.SetActive(false);
    }
    public void addcombo(int i)
    {
        combo += i;
    }
    public void resetcombo()
    {
        combo = 0;
    }
    public int getCombo()
    {
        return combo;
    }
}
