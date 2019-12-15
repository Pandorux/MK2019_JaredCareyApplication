using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    ScoreSystem scoreSystem;
    public bool destroyOnPickUp;
    public float increasePoints;
    public float increaseMultiplier;
    public Animator animator;
    public string animationToPlayOnPickup;
    public string defaultAnimation;

    void Start()
    {
        scoreSystem = GameObject.Find("GameUI")?.GetComponent<ScoreSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            PickedUp();
        }
    }

    void PickedUp()
    {
        if(scoreSystem != null)
        {
            scoreSystem.AddPoints(increasePoints);
            scoreSystem.IncreaseMultiplier(increaseMultiplier);
        }

        if(destroyOnPickUp)
        {
            // TODO: Add Fade out effect
            gameObject.SetActive(false);
        }
        else
        {
            if (animator != null)
            {
                animator.Play(animationToPlayOnPickup);
            }
        }
    }

    public void Reset() 
    {
        if (animator != null)
        {
            animator.Play(defaultAnimation);
        }

        if(destroyOnPickUp)
        {
            gameObject.SetActive(true);
        }
    }
}
