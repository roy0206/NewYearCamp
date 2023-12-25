using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayerStatus;
using Mono.Cecil;

public class Player : MonoBehaviour
{
    public float speed;
    public float hp;
    public bool isAllowedDamage;
    public bool isJumping, isSliding, allowDamaged;


    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        speed = GameManager.instance.info.baseSpeed;
        hp = GameManager.instance.info.baseHp;
        isAllowedDamage = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        Move();
        GetInput();
        if (hp <= 0) EndGame();
    }

    void Move()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void EndGame()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    void GetInput()
    {
        if(Input.GetKey(GameManager.instance.info.jumpKey)) isJumping = true;
        else isJumping = false;

        if(Input.GetKey(GameManager.instance.info.SlideKey)) isSliding = true;
        else isSliding = false;
    }

    public void GetDamaged()
    {
        if (allowDamaged)
        {
            hp -= 1;
            allowDamaged = false;
            Invoke("AllowDamaged", 2f);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, 12);
            animator.SetBool("do_jump", true);
            isSliding = false;

            return;
        }

        if (isSliding)
        {
            animator.SetBool("do_slide", true);
        }
        else animator.SetBool("do_slide", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("do_jump", false);
    }

    void AllowDamaged()
    {
        allowDamaged = true;
    }

}
