using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public Text scoreText;
    public Image backgroundImg;

    public bool isShowned = false;

    private float transition = 0.0f;
    void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (!isShowned)     
            return;
        transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
        
    }

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        isShowned = true;
    }
}
