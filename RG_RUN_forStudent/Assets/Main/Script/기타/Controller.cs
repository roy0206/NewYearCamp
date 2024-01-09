using PlayerStatus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour
{

    [HideInInspector]
    public Player player;

    public float setTime = 0f;

    public float doubleJumpInterval;
    float minInterval = 0.01f;
    float maxInterval = 0.5f;
    public bool allowDoubleJump = true;

    Rigidbody2D rb;
    Animator animator;
    CapsuleCollider2D capsuleCollider1;
    CapsuleCollider2D capsuleCollider2;

    public State currentState;
    public List<State> states;

    public GameObject winUi;
    public GameObject failUi;
    public bool isShowingUi = false;

    void Start()
    {
        //player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player =GetComponent<Player>();

        states = new List<State>
        {new Idle(), new Run()};
        ChangeState(states[0]);

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider1 = GetComponents<CapsuleCollider2D>()[0];
        capsuleCollider2 = GetComponents<CapsuleCollider2D>()[1];

        transform.localScale = new Vector3(0.6f,0.6f,1);

    }

    // Update is called once per frame
    void Update()
    {
        Execute();
        CheckCoolTime();
        DoubleJump();


        if (animator.GetBool("do_slide"))
        {
            capsuleCollider1.enabled = false;
            capsuleCollider2.enabled = true;
        }
        else
        {
            capsuleCollider1.enabled = true;
            capsuleCollider2.enabled = false;
        }

        if (player.hp <= 0 || player.transform.position.y < -20) EndGame(false);
    }

    public void ChangeState(State newState)
    {
        if (newState == null) return;

        currentState = newState;
        currentState.Enter(this);
    }

    void Execute()
    {
        if (currentState != null) currentState.Execute(this);
    }

    void DoubleJump()
    {
        if(Input.GetKeyDown(GameManager.instance.info.jumpKey)
            && doubleJumpInterval > minInterval
            && doubleJumpInterval < maxInterval && allowDoubleJump)
        {
            allowDoubleJump = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 8);
            animator.SetBool("double_jump", true);
        }
        if (Input.GetKeyUp(GameManager.instance.info.jumpKey)) doubleJumpInterval = 0;
        if (player.isJumping == false)
        {
            doubleJumpInterval += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        allowDoubleJump = true;
        animator.SetBool("double_jump", false);
    }


    void CheckCoolTime()
    {
        setTime -= Time.unscaledDeltaTime;
        

        if (setTime == 0 && currentState == states[0]) return;
        if (setTime < 0)
        {
            setTime = 0;
            ChangeState(states[0]);
            return;
        }
    }

    bool isFinished = false;
    public void EndGame(bool win)
    {
        if (!isFinished && !isShowingUi)
        {
            isShowingUi = true;
            if (win) winUi.SetActive(true);
            else failUi.SetActive(true);
            Time.timeScale = 0;
            player.gameObject.SetActive(false);
        }
    }
}
