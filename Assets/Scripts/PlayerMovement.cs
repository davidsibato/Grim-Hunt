using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Timeline;
using UnityEngine.UI;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public PlayerState currentState;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D myRigidbody;
    [SerializeField] Vector3 change;
    [SerializeField] Animator animator;
    [SerializeField] FixedJoystick joystick;
    [SerializeField] public FloatValue currentHeath;
    public GameEvent playerHealthEvent;
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        joystick = GameObject.FindWithTag("FixedJoystick").GetComponent<FixedJoystick>();
        animator.SetFloat("MoveX", 0);
        animator.SetFloat("MoveY", -1);
    }

    void Update()
    {
        
        change = Vector3.zero;
        //change.x = Input.GetAxisRaw("Horizontal");
        //change.y = Input.GetAxisRaw("Vertical");
        change.x = Mathf.RoundToInt(joystick.Horizontal);
        change.y = Mathf.RoundToInt(joystick.Vertical);

        if (currentState!=PlayerState.walk || currentState != PlayerState.idle)
        {
        //    StartCoroutine(AttackCo());
        //}
        //else if(currentState==PlayerState.walk || currentState == PlayerState.idle)
        //{
            UpdateAnimationAndMove();
        }
        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
             Attack();
        }
    }

    private IEnumerator AttackCo()
    {
        
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        currentState = PlayerState.walk;
        yield return new WaitForSeconds(.2f);
        
    }
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MovePlayer();
            animator.SetFloat("MoveX", change.x);
            if(change.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f);
            }
            animator.SetFloat("MoveY", change.y);
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    private void MovePlayer()
    {
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    public void Knock(float knockTime, float damage)
    {

        currentHeath.initialValue -= damage;
        if (currentHeath.initialValue > 0)
        {
            playerHealthEvent.Raise();
            StartCoroutine(KnockCo(knockTime));
        }
        
    }
    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
    public void Attack()
    {
        if (currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
    }
    
}
