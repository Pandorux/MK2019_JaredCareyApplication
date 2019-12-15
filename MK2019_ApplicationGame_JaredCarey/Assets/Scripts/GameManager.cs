using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action onPlayerDie;
    public static void onPlayerDied() 
    {
        Time.timeScale = 0;
        onPlayerDie();
        Debug.Log("Player has died");
    }

    void Start()
    {
        Time.timeScale = 1;
    }

}
