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
            Destroy(gameObject);
        }
        else
        {
            if (animator != null)
            {
                animator.Play(animationToPlayOnPickup);
            }
        }
    }
}
