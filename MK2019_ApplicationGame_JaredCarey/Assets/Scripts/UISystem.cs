using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UISystem : MonoBehaviour
{
    protected ScoreSystem scoreSystem;
    [Range(0, 3)]
    public TMP_Text scoreText;
    public TMP_Text multiplierText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Pause() 
    {
        Time.timeScale = 0;
    }
    
    public void Unpause() 
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() 
    {
        Application.Quit();
    }

    protected void UpdateUI()
    {
        if(scoreSystem != null) 
        {
            scoreText.text = $"Score: {scoreSystem.GetScore()}";
            multiplierText.text = $"x{scoreSystem.GetMultiplier()}";
        }
    }
}
