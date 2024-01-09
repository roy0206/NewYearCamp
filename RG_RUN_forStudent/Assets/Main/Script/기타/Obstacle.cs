using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Player player; Controller controller;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        controller = GameObject.FindWithTag("Player").GetComponent<Controller>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (controller.currentState == controller.states[1])
            {
                Destroy(gameObject);
            }
            else
            {
                player.GetDamaged();
            }
        }

    }
}



