using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    protected float score = 0;
    [Tooltip("In Seconds. How often does the player recieves points for survival.")]
    [Range(0, 10)]
    protected float pointsIncreaseRate = 1;
    protected float scoreMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IncreaseScoreOverTime(pointsIncreaseRate));
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(IncreaseScoreMultiplier());
    }

    public int GetScore() 
    {
        return (int)score;
    }

    public AddPoints(int points) 
    {
        score += points * scoreMultiplier;
    }

    protected void IncreaseScoreMultiplier(int amt) 
    {
        scoreMultiplier += amt;
    }

    protected IEnumerator IncreaseScoreOverTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        AddPoints();
    }

}
