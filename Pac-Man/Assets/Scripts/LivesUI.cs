using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public static int lives = 3;
    public static int lifeIncreaseCounter = 0;
    public int lifeIncreaseLimit = 100;
    Transform lifeIcon1;
    Transform lifeIcon2;
    Transform lifeIcon3;


    // Start is called before the first frame update
    void Start()
    {
        lifeIcon1 = transform.Find("LifeIcon1");
        lifeIcon2 = transform.Find("LifeIcon2");
        lifeIcon3 = transform.Find("LifeIcon3");
    }

    // Update is called once per frame
    void Update()
    {
        if (lives < 3)
        {
            lifeIcon3.gameObject.SetActive(false);
        } 
        if (lives < 2)
        {
            lifeIcon2.gameObject.SetActive(false);
        }
        if (lives < 1)
        {
            lifeIcon1.gameObject.SetActive(false);
        }

        if (lifeIncreaseCounter > lifeIncreaseLimit && lives < 3)
        {
            lives++;
            if (lives == 2)
            {
                lifeIcon2.gameObject.SetActive(true);
            } 
            if (lives == 3)
            {
                lifeIcon3.gameObject.SetActive(true);
            }
        }
    }
}
