using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Transform _transform;
    private float currentRotation;
    public float speed = 5f;
    private void Awake()
    {
        _transform = transform;
        currentRotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentRotation += Time.deltaTime * speed;
        _transform.rotation = Quaternion.Euler(0,currentRotation,0);
    }
}
