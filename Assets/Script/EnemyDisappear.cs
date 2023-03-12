using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisappear : MonoBehaviour
{
    public Vector2 direction = new Vector2 (0, 1);
    public float speed = 8f;
    public bool isDisappear;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (isDisappear)
        {
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    public void EnnemyDisappear()
    {
        isDisappear = true;
        OnBecameInvisible();
    }
}
