using PlayerStatus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    [HideInInspector]
    public Player player;

    public float setTime = 0f;
    [SerializeField] Text countdownText;

    public float doubleJumpInterval;
    float minInterval = 0.01f;
    float maxInterval = 0.3f;
    public bool allowDoubleJump = true;

    Rigidbody2D rb;
    Animator animator;

    public State currentState;
    public List<State> states;

    void Start()
    {
        //player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player =GetComponent<Player>();
        countdownText.text = setTime.ToString();

        states = new List<State>
        {new Idle(), new Run()};
        ChangeState(states[0]);

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Execute();
        CheckCoolTime();
        countdownText.text = setTime.ToString("F2");
        DoubleJump();
        print(allowDoubleJump);
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
            print(minInterval);
            print(maxInterval);
            allowDoubleJump = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 8);
            animator.SetBool("do_jump", true);
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (currentState == states[1])
            {
                Destroy(collision.gameObject);
            }
            else
            {
                player.GetDamaged();
            }
        }

    }

}
