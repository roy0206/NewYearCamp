using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;     // �����̴� �ӵ�. public���� �����Ͽ� ����Ƽ ȭ�鿡�� ������ �� �ִ�.
    public float hp = 3;
    float h, v;

    [SerializeField]
    float setTime = 0f;
    [SerializeField]
    Text countdownText;
    void Start()
    {
        Debug.Log(hp);
        countdownText.text = setTime.ToString();
    }


    void Update()
    {
        h = Input.GetAxis("Horizontal");        
        v = Input.GetAxis("Vertical");          

        transform.position += new Vector3(h, v, 0) * speed * Time.deltaTime;


        if (speed == 15.0f)
        {
            setTime += Time.deltaTime;
            countdownText.text = setTime.ToString("F2");
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle");
            if (speed == 15.0f)
            {
                Debug.Log("Break");
                Destroy(collision.gameObject);//�ε��� ������Ʈ ����
            }
            else
            {
                hp -= 1;
                Debug.Log("HP : " + hp);
            }
 

        }
    }
}