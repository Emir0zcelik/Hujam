using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
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
    private LayerMask layer;
    public MovingState(EnemyAI enemyAI, float radius, LayerMask layer) : base(enemyAI)
    {
       this.radius = radius;
       this.layer = layer; 
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

        Collider[] hitColliders = Physics.OverlapSphere(enemyAI.cacheTransform.position, radius, layer);

        if (hitColliders.Length > 0 )
        {
            enemyAI.ChangeState(new FightingState(enemyAI, hitColliders[0].GetComponent<Building>(), layer));
        }
    }

    public override void OnStateUpdate()
    {
        
    }
}

public class FightingState : EnemyState
{
    Building building;
    LayerMask targetLayer;
    public FightingState(EnemyAI enemyAI, Building building, LayerMask targetLayer) : base(enemyAI)
    {
        this .building = building;
        this .targetLayer = targetLayer;
    }

    public override void OnStateEnter()
    {
        enemyAI.rb.velocity = Vector3.zero;
    }

    public override void OnStateExit()
    {

    }

    public override void OnStateFixedUpdate()
    {

        if (building.health <= 0) 
        {
            enemyAI.ChangeState(new MovingState(enemyAI, enemyAI.radius, targetLayer));
        }

        if (Physics.Raycast(enemyAI.cacheTransform.position, enemyAI.cacheTransform.forward, 20.0f, enemyAI.targetLayer)) 
        {
            building.TakeDamage(enemyAI.damage);
        }
    }

    public override void OnStateUpdate()
    {

    }

}
