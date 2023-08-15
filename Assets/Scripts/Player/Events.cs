using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public Button retry;
    public Button mainmenu;

     void Start()
    {
        mainmenu.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Menu");
        });
        retry.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Level");
        });
    }
    /*public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }*/
}
