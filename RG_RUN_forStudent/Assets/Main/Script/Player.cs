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

    [Space]

    public GameObject heartLayout;
    public GameObject heartPrefab;
    public Sprite redHeart;
    public Sprite voidHeart;
    Image[] hearts;

    Rigidbody2D rb;

    void Start()
    {
        speed = GameManager.instance.info.baseSpeed;
        hp = GameManager.instance.info.baseHp;
        maxHp = GameManager.instance.info.baseHp;
        isAllowedDamage = true;

        rb = GetComponent<Rigidbody2D>();

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
    }

    void Move()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }



    void GetInput()
    {

    }

    public void GetDamaged()
    {

    }
    void AllowDamaged()
    {

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


}
