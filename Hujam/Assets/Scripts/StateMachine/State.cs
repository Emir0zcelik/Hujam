using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();
    public abstract void OnStateFixedUpdate();
    public abstract void OnStateExit();
}

public class EnemyState : State
{
    protected EnemyAI enemyAI;

    public EnemyState(EnemyAI enemyAI)
    {
        this.enemyAI = enemyAI;
    }

    public virtual void  OnStateEnter()
    {
        
    }

    public virtual void OnStateExit()
    {

    }

    public virtual void OnStateFixedUpdate()
    {

    }

    public virtual void OnStateUpdate()
    {

    }
}

public class MovingState : EnemyState
{
    public MovingState(EnemyAI enemyAI) : base(enemyAI)
    {

    }

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateFixedUpdate()
    {
        Rigidbody rb = enemyAI.GetComponent<Rigidbody>();

        Vector3 direction = (Vector3.zero - rb.position).normalized;
        float movementSpeed = enemyAI.movementSpeed;

        rb.velocity = direction * movementSpeed;
    }

    public override void OnStateUpdate()
    {
        
    }
}
