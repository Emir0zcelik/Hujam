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
    private float radius;
    public MovingState(EnemyAI enemyAI, float radius) : base(enemyAI)
    {
       this.radius = radius;
    }

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateFixedUpdate()
    {
        Vector3 direction = (Vector3.zero - enemyAI.rb.position).normalized;

        float movementSpeed = enemyAI.movementSpeed;

        enemyAI.rb.velocity = direction * movementSpeed;

        direction.y = 0;
        
        enemyAI.transform.LookAt(direction);

        Collider[] hitColliders = Physics.OverlapSphere(enemyAI.cacheTransform.position, radius);

        if (hitColliders.Length > 0 )
        {
            enemyAI.currentState = new FightingState(enemyAI, hitColliders[0].GetComponent<Building>());
        }
    }

    public override void OnStateUpdate()
    {
        
    }
}

public class FightingState : EnemyState
{
    Building building;
    public FightingState(EnemyAI enemyAI, Building building) : base(enemyAI)
    {
        this .building = building;
    }

    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {

    }

    public override void OnStateFixedUpdate()
    {
    }

    public override void OnStateUpdate()
    {

    }

}
