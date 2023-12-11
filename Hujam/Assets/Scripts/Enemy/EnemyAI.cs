using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : StateMachine
{
	public Rigidbody rb;
    public float movementSpeed = 5.0f;
    public float health;
    public Transform cacheTransform;
    public float radius;
    public float damage = 10f;
    public LayerMask targetLayer;
    

    private void Awake()
    {
        targetLayer = LayerMask.GetMask("Tower");
        cacheTransform = transform;
        currentState = new MovingState(this, radius, targetLayer);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)  
        {
            DestroyEnemy();
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

}
