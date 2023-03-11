using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blob : EnemyAttack
{

    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform attackTarget;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if ( Vector3.Distance(target.position,
                                transform.position) <= chaseRadius
                                && Vector2.Distance(target.position,
                                transform.position)> attackRadius)
        {
            Vector3 temp = Vector2.MoveTowards(transform.position, target.position, speed* Time.deltaTime);
            myRigidbody.MovePosition(temp);
        }
    }
}
