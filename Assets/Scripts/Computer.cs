using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    Rigidbody2D rbody = new Rigidbody2D();
    Animator anime = new Animator();
    SpriteRenderer sprite = new SpriteRenderer();
    public bool Flash;
    public float PaddleSpeed;

    LebronMovement lebron;
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
       if(this.transform.localPosition.y > -4.26 && lebron.transform.position.y < this.transform.localPosition.y)
        {
            this.transform.localPosition += new Vector3(0, -PaddleSpeed * Time.deltaTime, 0);
        }
       if(this.transform.localPosition.y  < 4.81 && lebron.transform.position.y > this.transform.localPosition.y)
        {
            this.transform.localPosition += new Vector3(0, PaddleSpeed * Time.deltaTime, 0);
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
