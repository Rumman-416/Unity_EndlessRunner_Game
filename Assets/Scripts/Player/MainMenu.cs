using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text highScoreText;
    public Text Kills;

    public Button play;
    public Button quit;

     void Start()
    {
        highScoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
        Kills.text = ": " + PlayerPrefs.GetInt("kills");

        play.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Level");
        });
        quit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
  /*  public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }*/
}
