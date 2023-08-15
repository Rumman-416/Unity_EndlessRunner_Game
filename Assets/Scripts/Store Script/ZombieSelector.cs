using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSelector : MonoBehaviour
{
    public int currentZombieIndex ;
    public  GameObject[] Zombie;

    void Start()
    {
        currentZombieIndex = PlayerPrefs.GetInt("SelectedZombie", 0);
        foreach (GameObject Zombie in Zombie)
            Zombie.SetActive(false);

        Zombie[currentZombieIndex].SetActive(true);
    }

}
