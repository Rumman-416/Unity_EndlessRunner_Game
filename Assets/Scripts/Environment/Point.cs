using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("kills");
            PlayerManager.numberOfCoins ++;
            PlayerPrefs.SetInt("kills", PlayerManager.numberOfCoins);
            Destroy(gameObject);

        }
    }
}
