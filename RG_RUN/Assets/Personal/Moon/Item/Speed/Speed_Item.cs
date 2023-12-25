using System.Collections;
using UnityEngine;

public class Speed_Item : MonoBehaviour
{
    GameObject player;
    public SpriteRenderer spriteRenderer;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Speed_Item");
            Controller con = collision.gameObject.GetComponent<Controller>();
            con.ChangeState(con.states[1]);

            DestroySprite(); // ��������Ʈ = none
            Destroy(gameObject, 2f);
        }
    }

    public void DestroySprite()
    {
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();

        // Sprite Renderer�� ��Ȱ��ȭ�Ͽ� ��������Ʈ�� "None"���� ����
        spriteRenderer.enabled = false;

    }
}
