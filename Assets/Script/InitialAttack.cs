using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialAttack : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public GameEvent gameEvent;
    public bool attacking = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (attacking)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }
    public void initialAttck()
    {
        attacking= true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameEvent.Raise();
            Destroy(gameObject);
            
        }
    }
}



