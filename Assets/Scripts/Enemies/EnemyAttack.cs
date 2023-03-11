using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    walking,
    stagger,
    idle
}
public class EnemyAttack : MonoBehaviour
{

    [SerializeField] public float health;
    [SerializeField] public FloatValue maxHealth;
    [SerializeField] public string enemyName;
    [SerializeField] public int baseAttack;
    [SerializeField] public float speed;
    [SerializeField] public EnemyState currentState;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= -10)
        {
            this.gameObject.SetActive(false);
        }
    }
    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockEnemy(myRigidbody, knockTime));
        TakeDamage(damage);
    }
    private IEnumerator KnockEnemy(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
