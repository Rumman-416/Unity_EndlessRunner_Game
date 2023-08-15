using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    private float score = 0.0f;

    public Text scoreText;
    public static bool isGameStarted;
    public DeathMenu deathMenu;
    private bool isDead = false;
    void Start()
    {
        isGameStarted = false;
    }


    void Update()
    {
        if (isDead)
        {
            return;
        }
        score += 0.9f * Time.deltaTime;
        scoreText.text = ((int)score).ToString();
    }

    public void OnDeath()
    {
        isDead = true;
        if(PlayerPrefs.GetFloat("HighScore")<score)
        PlayerPrefs.SetFloat("HighScore", score);

        deathMenu.ToggleEndMenu(score);
    }
}
