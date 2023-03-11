using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu (fileName = "New Enemy", menuName = "Enemy")]

public class EnemyData : ScriptableObject
{
    [SerializeField] string m_name;
    [SerializeField] int m_maxHealth;

    [ShowAssetPreview]
    [SerializeField] Sprite m_enemySprite;
}
