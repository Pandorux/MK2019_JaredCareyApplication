using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action onPlayerDie;
    public static bool canLoadNewLevel = true;
    public static void onPlayerDied() 
    {
        Time.timeScale = 0;
        onPlayerDie();
        Debug.Log("Player has died");
    }

    void Awake()
    {
        Time.timeScale = 1;
        canLoadNewLevel = true;
    }

}
