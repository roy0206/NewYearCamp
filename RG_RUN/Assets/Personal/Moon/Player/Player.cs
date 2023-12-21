using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayerStatus;

public class Player : MonoBehaviour
{
/*    [HideInInspector]*/
    public float speed = 10.0f;     // 움직이는 속도. public으로 설정하여 유니티 화면에서 조정할 수 있다.
    public float hp = 3;
    public bool isAllowedDamage;
    float h, v;

    public float setTime = 0f;
    [SerializeField] Text countdownText;

    public State currentState;
    public List<State> states;

    private void Awake()
    {
        //상태 관리
        states = new List<State>
        {new Idle(), new Run()};
        ChangeState(states[0]);
    }

    void Start()
    {
        countdownText.text = setTime.ToString();

        speed = GameManager.instance.info.baseSpeed;
        hp = GameManager.instance.info.baseHp;
        isAllowedDamage = true;

    }


    void Update()
    {
        Move();
        CheckCoolTime();
        if (hp <= 0) EndGame();
        Execute();
    }

    void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        transform.position += new Vector3(h, v, 0).normalized * speed * Time.deltaTime;
    }

    void EndGame()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    void Execute()
    {
        if (currentState != null) currentState.Execute(this);
    }

    public void ChangeState(State newState)
    {
        if (newState == null) return;

        currentState = newState;
        currentState.Enter(this);
    }

    void CheckCoolTime()
    {
        setTime -= Time.deltaTime;
        countdownText.text = setTime.ToString("F2");

        if (setTime == 0 && currentState == states[0]) return;
        if (setTime < 0)
        {
            setTime = 0;
            ChangeState(states[0]);
            return;
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
                Destroy(collision.gameObject);//부딪힌 오브젝트 제거
            }
            else
            {
                hp -= 1;
                Debug.Log("HP : " + hp);
                if (hp <= 0)
                {

                    SceneManager.LoadScene("GameOverScene");
                }
            }
        }

    }

}
