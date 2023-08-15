using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopManager : MonoBehaviour
{
    public int currentZombieIndex;
    public GameObject[] ZombieModels;


    void Start()
    {

        currentZombieIndex = PlayerPrefs.GetInt("SelectedZombie", 0);
        foreach (GameObject Zombie in ZombieModels)
            Zombie.SetActive(false);

        ZombieModels[currentZombieIndex].SetActive(true);

    }


    void Update()
    {
   
    }

    public void ChangeNext()
    {
        ZombieModels[currentZombieIndex].SetActive(false);

        currentZombieIndex++;
        if (currentZombieIndex == ZombieModels.Length)
            currentZombieIndex = 0;

        ZombieModels[currentZombieIndex].SetActive(true);

        PlayerPrefs.SetInt("SelectedZombie", currentZombieIndex);
    }


    public void ChangePrevious()
    {
        ZombieModels[currentZombieIndex].SetActive(false);

        currentZombieIndex--;
        if (currentZombieIndex == -1)
            currentZombieIndex = ZombieModels.Length -1;

        ZombieModels[currentZombieIndex].SetActive(true);

        PlayerPrefs.SetInt("SelectedZombie", currentZombieIndex);
    }

   
}
