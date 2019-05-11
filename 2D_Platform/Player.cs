using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    bool jump = false;
    float vel = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * vel, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && jump == false)
        {
            rb.AddForce(new Vector2(0, 300));
            jump = true;
        }

        if(move > 0)
        {
            transform.eulerAngles = new Vector2(0,0);
        }
        else if(move < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    { 
        if(col.gameObject.tag == "floor")
        {
            jump = false;
        }
        
    }
}
