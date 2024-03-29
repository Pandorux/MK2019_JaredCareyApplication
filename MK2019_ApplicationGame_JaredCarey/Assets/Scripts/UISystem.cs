﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UISystem : MonoBehaviour
{
    [SerializeField]
    protected ScoreSystem scoreSystem;
    public TMP_Text scoreText;
    public TMP_Text multiplierText;
    public GameObject gameOverScreen;
    public TMP_Text gameOverText;
    public GameObject loadScreen;

    // Start is called before the first frame update
    void Start()
    {
        if(scoreSystem != null)
        {
            scoreSystem.onScoreChange += UpdateUI;
        }
        
        GameManager.onPlayerDie += ShowGameOverScreen;
        UpdateUI();
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

    public void LoadScene(string sceneName)
    {
        SetAllUIInteractability(false);
        SceneManager.LoadScene(sceneName);
    }

    protected void UpdateUI()
    {
        if(scoreSystem != null) 
        {
            scoreText.text = $"Score: {scoreSystem.GetScore()}";
            multiplierText.text = $"x{scoreSystem.GetMultiplier()}";
        }
    }

    protected void ShowGameOverScreen()
    {
        if(gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
            gameOverText.text = $"You scored {scoreSystem.GetScore()} points!!";
        }
    }

    protected void SetAllUIInteractability(bool isInteractable)
    {
        GetComponent<GraphicRaycaster>().enabled = isInteractable;
    }

    // protected IEnumerator LoadSceneWithFadeOut(string sceneName)
    // {
    //     GameManager.canLoadNewLevel = false;
    //     loadScreen.SetActive(true);
    //     Animator animator = loadScreen.GetComponent<Animator>();
    //     animator.Play("FadeOut");
    //     yield return new WaitForSeconds(1.0f);
    //     SceneManager.LoadScene(sceneName);
    // }

}
