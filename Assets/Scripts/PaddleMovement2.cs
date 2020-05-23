using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement2 : MonoBehaviour
{

    Rigidbody2D rbody = new Rigidbody2D();
    Animator anime = new Animator();
    SpriteRenderer sprite = new SpriteRenderer();
    public bool Flash;
    public float PaddleSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rbody.velocity = new Vector2(0f, PaddleSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rbody.velocity = new Vector2(0f, -PaddleSpeed);
        }
        else
        {
            rbody.velocity = new Vector2(0f, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anime.SetBool("Flash", Flash);
        if (collision.collider.name == "Leebron")
        {
            Flash = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anime.SetBool("Flash", Flash);
        if (collision.collider.name == "Leebron")
        {
            Flash = false;
        }
    }
}