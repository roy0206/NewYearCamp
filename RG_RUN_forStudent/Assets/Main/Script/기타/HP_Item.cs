using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Item : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(player.GetComponent<Player>().hp < GameManager.instance.info.baseHp)
                player.GetComponent<Player>().hp += 1;

            Debug.Log("HP : " + player.GetComponent<Player>().hp);
            Destroy(gameObject);

        }
    }
}
