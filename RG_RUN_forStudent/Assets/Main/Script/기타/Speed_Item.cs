using System.Collections;
using UnityEngine;

public class Speed_Item : MonoBehaviour
{
    SpriteRenderer spriteRenderer;


    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Speed_Item");
            Controller con = collision.gameObject.GetComponent<Controller>();
            con.ChangeState(con.states[1]);

            DestroySprite(); // 스프라이트 = none
            Destroy(gameObject, 2f);
        }
    }

    public void DestroySprite()
    {
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();

        // Sprite Renderer를 비활성화하여 스프라이트를 "None"으로 변경
        spriteRenderer.enabled = false;

    }
}
