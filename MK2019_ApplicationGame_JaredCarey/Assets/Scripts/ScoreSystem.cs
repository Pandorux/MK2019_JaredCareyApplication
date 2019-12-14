using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    protected float score = 0;
    [Tooltip("In Seconds. How often does the player recieves points for survival.")]
    [Range(0, 10)]
    [SerializeField]
    protected float pointsIncreaseRate = 1;
    protected float scoreMultiplier = 1;


    public event Action onScoreChange;
    public void onScoreChanged()
    {
        if (onScoreChange != null)
        {
            onScoreChange();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IncreaseScoreOverTime(pointsIncreaseRate));
    }

    public int GetScore() 
    {
        return (int)score;
    }

    public int GetMultiplier() 
    {
        return (int)scoreMultiplier;
    }

    public void AddPoints(int points) 
    {
        score += points * scoreMultiplier;
        onScoreChanged();
        Debug.Log($"Current Score: {score}");
    }

    protected void IncreaseScoreMultiplier(int amt) 
    {
        scoreMultiplier += amt;
        onScoreChanged();
    }

    protected IEnumerator IncreaseScoreOverTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        AddPoints(1);
        StartCoroutine(IncreaseScoreOverTime(pointsIncreaseRate));
    }

}
