using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pacdot : MonoBehaviour
{
        void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.name == "Pac-Man")
        {
            ScoreUI.scoreValue += 10;
            if (LivesUI.lives < 3)
            {
                LivesUI.lifeIncreaseCounter++; 
            }
            Destroy(gameObject);

            if (ScoreUI.scoreValue == 3270)
            {
                SceneManager.LoadScene("GameCompleteScreen");
            }
        }    
    }
}
