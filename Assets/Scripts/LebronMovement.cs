using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LebronMovement : MonoBehaviour
{
    private Rigidbody2D rb = new Rigidbody2D();

    public GameObject Paddle1;
    public GameObject Paddle2;



    // Start is called before the first frame update

    void Start()
    {
       rb = GameObject.Find("Leebron").GetComponent<Rigidbody2D>();

        Paddle1 = GameObject.Find("Paddle1");
        Paddle2 = GameObject.Find("Paddle2");

       StartCoroutine(Pause());
    }

    // Update is called once per frame
    void Update()
    {
       if (this.transform.position.x >= 4.26f || this.transform.position.x <= -4f)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
      if (this.transform.position.x < 4.26f && this.transform.position.x > -4f)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }

      if(this.transform.position.x >= 10f)
        {
            Score.CanAdd1 = true;
            this.transform.position = new Vector3(0f, 0f, 0f);
            StartCoroutine(Pause());
           
        }
      if(this.transform.position.x <= -9.8f)
        {
            Score.CanAdd2 = true;
            this.transform.position = new Vector3(0f, 0f, 0f);
            StartCoroutine(Pause());
        }
      
    }

    IEnumerator Pause()
    {
        int xdirection = Random.Range(-1, 2);
        int ydirection = Random.Range(-1, 2);

        if (xdirection == 0)
        {
            xdirection = 1;
        }

        rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(1);
        rb.velocity = new Vector2(10f * xdirection, 10f * ydirection);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.name == "Paddle1")
        {
            if(Paddle1.GetComponent<Rigidbody2D>().velocity.y > 0.5f)
            {
                Debug.Log("poop");
                rb.velocity = new Vector2(10f, 10f);
            }
            else if (Paddle1.GetComponent<Rigidbody2D>().velocity.y < -0.5f)
            {
                rb.velocity = new Vector2(10f, -10f);
            }
            else
            {
                rb.velocity = new Vector2(12f,0f);
            }
        }
       if(collision.gameObject.name == "Paddle2")
        {
            if (Paddle2.GetComponent<Rigidbody2D>().velocity.y > 0.5f)
            {
                rb.velocity = new Vector2(-10f, 10f);
            }
            else if (Paddle2.GetComponent<Rigidbody2D>().velocity.y < -0.5f)
            {
                rb.velocity = new Vector2(-10f, -10f);
            }
            else
            {
                rb.velocity = new Vector2(-12f, 0f);
            }
        }
    }
}
