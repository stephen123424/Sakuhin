using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class level : MonoBehaviour
{
    public static Stack previosLevel;
    public void StartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void restartlvl1()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }



    public void retrybutton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
        Time.timeScale = 1;
    }
    public void retryScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    private IEnumerator wait(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
