using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public struct Timer
{
    public float currentTime;
    public float targetTime;

    public Timer(float targetTime, float currentTime)
    {
        this.targetTime = targetTime;
        this.currentTime = currentTime;
    }

    public void Tick()
    {
        currentTime += Time.deltaTime;
    }

    public float ExponentialTime()
    {
        return currentTime + Mathf.Exp(currentTime);
    }

    public bool IsDone()
    {
        return currentTime >= targetTime;
    }
}

