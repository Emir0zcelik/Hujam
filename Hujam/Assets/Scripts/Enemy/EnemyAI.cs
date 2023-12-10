using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : StateMachine
{
	public Rigidbody rb;
    public float movementSpeed = 5.0f;

    private void Awake()
    {
        currentState = new MovingState(this);
    }

}
