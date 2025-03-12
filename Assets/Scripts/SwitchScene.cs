using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void PlayNormal()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayPvP()
    {
        SceneManager.LoadScene(2);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayPro()
    {
        SceneManager.LoadScene(3);
    }
    public void Achievements()
    {
        SceneManager.LoadScene(4);
    }
}
