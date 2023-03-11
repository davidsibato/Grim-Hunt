//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using NaughtyAttributes;

//public class Player : MonoBehaviour
//{
//    [SerializeField] float speed;
//    [SerializeField] float horizontalInput;
//    [SerializeField] float verticalInput;
//    private Animator animator;
//    [SerializeField] bool moveNorth;
//    [SerializeField] bool moveSouth;
//    [SerializeField] bool moveEast;
//    [SerializeField] bool moveWest;
//    protected Joystick joystick;
    


//    private void Start()
//    {
//        moveSouth = true;
//        animator = GetComponent<Animator>();

//    }

//    private void Update()
//    {
//        horizontalInput = Input.GetAxis("Horizontal");
//        verticalInput = Input.GetAxis("Vertical");

//        if(verticalInput > 0)
//        {
//            DisableOtherStates();
//            animator.SetBool("moveNorth", true);
//            moveNorth = true;
//        }
//        if(verticalInput < 0)
//        {
//            DisableOtherStates();
//            DisableOtherBools();
//            animator.SetBool("moveSouth", true);
//            moveSouth = true;
//        }

//        if(horizontalInput > 0)
//        {
//            DisableOtherStates();
//            DisableOtherBools();
//            animator.SetBool("moveEast", true);
//            moveEast = true;
//        }

//        if(horizontalInput < 0) 
//        {
//            DisableOtherStates();
//            DisableOtherBools();
//            animator.SetBool("moveWest", true);
//            moveWest = true;
//        }

//        if(horizontalInput == 0 && verticalInput == 0)
//        {
//            DisableOtherStates();
//        }

//        transform.Translate(Vector2.up *verticalInput * speed * Time.deltaTime);
//        transform.Translate(Vector3.right *horizontalInput * speed * Time.deltaTime);
//    }

//    private void DisableOtherStates()
//    {
//        animator.SetBool("moveNorth", false);
//        animator.SetBool("moveSouth", false);
//        animator.SetBool("moveEast", false);
//        animator.SetBool("moveWest", false);

//    }
//    private void DisableOtherBools()
//    {
//        moveNorth = false;
//        moveSouth = false;
//        moveEast = false;
//        moveWest = false;
//    }

//    [Button]
//    public void Attack()
//    {
//        if(moveNorth) animator.SetTrigger("fightNorth");
//        if(moveSouth) animator.SetTrigger("fightSouth");
//        if(moveEast) animator.SetTrigger("fightEast");
//        if(moveWest) animator.SetTrigger("fightWest");   
//    }
    
//}



//    //     Vector2 dir = Vector2.zero;
//    //     if (Input.GetKey(KeyCode.A))
//    //     {
//    //         dir.x = -1;
//    //         //animator.SetInteger("Direction", 3);
//    //     }
//    //     else if (Input.GetKey(KeyCode.D))
//    //     {
//    //         dir.x = 1;
//    //         //animator.SetInteger("Direction", 2);
//    //     }

//    //     if (Input.GetKey(KeyCode.W))
//    //     {
//    //         dir.y = 1;
//    //         //animator.SetInteger("Direction", 1);
//    //     }
//    //     else if (Input.GetKey(KeyCode.S))
//    //     {
//    //         dir.y = -1;
//    //         //animator.SetInteger("Direction", 0);
//    //     }

//    //     dir.Normalize();
//    //    // animator.SetBool("IsMoving", dir.magnitude > 0);

//    //     GetComponent<Rigidbody2D>().velocity = speed * dir;

