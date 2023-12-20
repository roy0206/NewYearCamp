using System.Collections;
using UnityEngine;

public class Speed_Item : MonoBehaviour
{
    GameObject player;
    public SpriteRenderer spriteRenderer;


    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Speed_Item");
            SpeedUp(); // speed를 15로
            DestroySprite(); // 스프라이트 = none
            Destroy(gameObject, 2f);
        }
    }

    public void DestroySprite()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        if (spriteRenderer != null)
        {
            SetSpriteToNone();
        }
    }

    void SetSpriteToNone()
    {
        // Sprite Renderer를 비활성화하여 스프라이트를 "None"으로 변경
        spriteRenderer.enabled = false;
    }


    float delay;
    public void SpeedUp()
    {
 
        if(player.GetComponent<Player>().speed == 15.0f)
        {
            delay += 1f;
            Debug.Log("Speed Up " + delay);
            return;
        }

        else if(player.GetComponent<Player>().speed == 10.0f)
        {
            delay += 1f;
            Debug.Log("Speed Up " + delay);
            
            player.GetComponent<Player>().speed = 15.0f;
            StartCoroutine(DelayedSpeedDown()); // DelayedSpeedDown 코루틴 시작
            return;
        }

    }

    // currentDelay 매개변수 추가
    public IEnumerator DelayedSpeedDown()
    {
        float curTime = 0f;

        while (curTime <= delay)
        {
            //Debug.Log(delay);
            curTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        SpeedDown();
    }

        public void SpeedDown()
    {
        Debug.Log("Speed Down");
        player.GetComponent<Player>().speed = 10.0f;
        
    }
}
