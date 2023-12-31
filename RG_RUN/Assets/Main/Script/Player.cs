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
    public int hp;
    public int maxHp;
    public bool isAllowedDamage;
    public bool isJumping, isSliding;

    Rigidbody2D rb;
    Animator animator;

    [Space]

    public GameObject heartLayout;
    public GameObject heartPrefab;
    public Sprite redHeart;
    public Sprite voidHeart;
    Image[] hearts;

    void Start()
    {
        speed = GameManager.instance.info.baseSpeed;
        hp = GameManager.instance.info.baseHp;
        maxHp = GameManager.instance.info.baseHp;
        isAllowedDamage = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        hearts = new Image[hp];
        for(int i = 0; i < hp; i++)
        {
            hearts[i] = Instantiate(heartPrefab).GetComponent<Image>();
            hearts[i].transform.SetParent(heartLayout.transform);
            hearts[i].transform.localScale = Vector3.one;
        }
    }


    void Update()
    {
        Move();
        GetInput();

        int i = 0;
        while (i < hp)
        {
            hearts[i].sprite = redHeart;
            i++;
        }

        while (i < maxHp) {
            hearts[i].sprite = voidHeart;
            i++;
        }

        if (hp <= 0) EndGame();

        print(isAllowedDamage);
    }

    void Move()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void EndGame()
    {
/*        SceneManager.LoadScene("GameOverScene");*/
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
        if (isAllowedDamage)
        {
            hp -= 1;
            isAllowedDamage = false;
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
        isAllowedDamage = true;
    }

}
