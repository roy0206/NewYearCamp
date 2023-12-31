using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float speed = 3f;
    public float jump_speed = 10.0f;
    Rigidbody2D rb;
    Transform tr;
    bool slide_key;
    public Vector2 slide_scale = new Vector3(1.6f, 0.75f, 1);
    public Vector2 default_scale = new Vector3(1, 1.6f, 1);
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Slide();
    }

    void Slide()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            slide_key = false;
        }
        if (slide_key)
        {
            tr.localScale = slide_scale;
            animator.SetBool("do_slide", true);
        }
        else
        {
            tr.localScale = default_scale;
            animator.SetBool("do_slide", false);
        }

    }
    void Move()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_speed);
            animator.SetBool("do_jump", true);
            slide_key = false;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            slide_key = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("do_jump", false);
    }
}
