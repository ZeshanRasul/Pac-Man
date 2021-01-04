using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    Animator animator;

    void Start()
    {
        dest = transform.position;
        animator = GetComponent<Animator>();

    }

    void FixedUpdate() 
    {
        Vector2 newPos = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(newPos);

        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
            }
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
            {
                dest = (Vector2)transform.position - Vector2.up;
            }
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
            {
                dest = (Vector2)transform.position - Vector2.right;
            }
        }

        Vector2 dir = dest - (Vector2)transform.position;
        animator.SetFloat("DirX", dir.x);
        animator.SetFloat("DirY", dir.y);
        
    }

    bool valid(Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        Debug.Log(pos);
        Debug.Log(dir);
        Debug.Log(hit.collider.name);
        return (hit.collider == GetComponent<Collider2D>());
    }

}
