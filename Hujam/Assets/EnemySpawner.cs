using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private float _time;
    public GameObject enemyPrefab;
    public float spawnDistance = 200f;
    public float baseMaxCooldown = 20;
    private float _cooldownTimer;
    public float cooldDownDecreaseRate = 0.05f;
    public float cooldDownDecreaseRate2 = 0.05f;
    public float minCoolDown = 2f;
    
    void Awake()
    {
        _time = 0;
        _cooldownTimer = baseMaxCooldown;
    }

    void Update()
    {
        _time += Time.deltaTime;
        _cooldownTimer -= Time.deltaTime;

        if (_cooldownTimer <= 0)
        {
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            randomDirection *= spawnDistance;
            Vector3 spawnPosition = new Vector3(randomDirection.x, 0, randomDirection.y);
            Instantiate(enemyPrefab, spawnPosition, quaternion.identity);

            cooldDownDecreaseRate += cooldDownDecreaseRate2;
            
            _cooldownTimer = Mathf.Max(minCoolDown, baseMaxCooldown - cooldDownDecreaseRate);
        }
    }
}
