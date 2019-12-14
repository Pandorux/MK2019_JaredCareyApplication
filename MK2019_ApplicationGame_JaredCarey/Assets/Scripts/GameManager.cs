using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action onPlayerDie;
    public static void onPlayerDied() 
    {
        if (onPlayerDie != null) 
        {
            Time.timeScale = 0;
            onPlayerDie();
        }
    }

}
