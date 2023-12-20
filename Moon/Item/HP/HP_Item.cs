using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Item : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("HP : " + player.GetComponent<Player>().hp);
            player.GetComponent<Player>().hp += 1;
            Destroy(gameObject);

        }
    }
}
