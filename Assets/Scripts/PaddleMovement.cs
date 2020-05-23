using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{

    Rigidbody2D rbody = new Rigidbody2D();
    Animator anime = new Animator();
    SpriteRenderer sprite = new SpriteRenderer();
    LebronMovement lebron;
    public float PaddleSpeed;
    public bool Flash;
    Menu menu;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        lebron = FindObjectOfType<LebronMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menu.Exit();
        }
        if(Input.GetKey(KeyCode.W))
        {
            rbody.velocity = new Vector2(0f, PaddleSpeed);
        }
        else if(Input.GetKey(KeyCode.S))
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
        if(collision.collider.name == "Leebron")
        {
            Flash = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anime.SetBool("Flash", Flash);
        if(collision.collider.name == "Leebron")
        {
            Flash = false;
        }
    }
}
