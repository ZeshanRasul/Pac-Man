using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pacdot : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.name == "Pac-Man")
        {
            ScoreUI.scoreValue += 10;
            LivesUI.lifeIncreaseCounter++; 
            Destroy(gameObject);

        }    
    }
}
