using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{

    public static bool gameOver;
    public GameObject DeathMenu;

    public static bool isGameStarted;
   // public GameObject startingText;

    public static int numberOfCoins;
    public Text coinsText;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
       // numberOfCoins = 0;
    }

    void Update()
    {
 
        coinsText.text = numberOfCoins.ToString();
        Debug.Log(numberOfCoins);
            isGameStarted = true;
            //Destroy(startingText);
            

    }

    private void Awake()
    {
        numberOfCoins = PlayerPrefs.GetInt("kills", 0);
    }
}
