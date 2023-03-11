// using UnityEngine;
// using UnityEngine.Events;
// public class EnemyHealth : MonoBehaviour
// {
//     EnemyProperties enemyProperties;
//     public UnityEvent onEnemyDeath;
//     public CustomFloatEvent onPlayerHurt;
//     public void TakeDamage(float damage)
//     {
//         enemyProperties.GetHealth() -= damage;
//         onEnemyHurt.Invoke(damage);
//         if(enemyProperties.GetHealth < 0)
//         {
//             onEnemyDeath.Invoke();
//         }
//     }
// }