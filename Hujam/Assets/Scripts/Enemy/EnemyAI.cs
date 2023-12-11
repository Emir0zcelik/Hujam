using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : StateMachine, IDamagable
{
	public Rigidbody rb;
    public float movementSpeed = 5.0f;
    public float health;
    public Transform cacheTransform;
    public float radius;
    public float damage = 10f;
    public LayerMask targetLayer;

    public ParticleSystem ParticleSystem;
    public AudioSource shotSource;

    public int destroyEarningAmount = 50;
    

    private void Awake()
    {
        cacheTransform = transform;
        currentState = new MovingState(this, radius, targetLayer);
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            PlayerStats.money += destroyEarningAmount;
            DestroyEnemy();
        }
    }
}
