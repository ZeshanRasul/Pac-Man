using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 0.3f;
    int cur = 0;
    Rigidbody2D rb;
    Animator animator;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void FixedUpdate() 
    {
        if (transform.position != waypoints[cur].position)
        {
            Vector2 newPos = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(newPos);
        } 
        else
        {
            cur = (cur + 1) % waypoints.Length;
        }

        Vector2 dir = waypoints[cur].position - transform.position;
        animator.SetFloat("DirX", dir.x);
        animator.SetFloat("DirY", dir.y);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.name == "Pac-Man")
        {
            LivesUI.lives--;

            if (LivesUI.lives == 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
