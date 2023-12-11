using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnMoneyInTime : MonoBehaviour
{
    public float earnTime = 1f;
    public int moneyAmount = 10;

    private float _timer;

    private void Awake()
    {
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= earnTime)
        {
            PlayerStats.money += moneyAmount;
            _timer = 0;
        }
    }
}
