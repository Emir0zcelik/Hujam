using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private float Health;
    [SerializeField] private float movementSpeed;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MonsterMovement();
    }

    void MonsterMovement()
    {
        rb.velocity = new Vector3(0.0f, 1.0f * movementSpeed, 0.0f);
    }
}
