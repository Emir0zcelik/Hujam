using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : StateMachine
{
	public Rigidbody rb;
    public float movementSpeed = 5.0f;
    public int health;

    private void Awake()
    {
        currentState = new MovingState(this);
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
