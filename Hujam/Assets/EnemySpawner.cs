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
    public float baseMaxCooldown = 10;
    private float _cooldownTimer;
    
    // Start is called before the first frame update
    void Awake()
    {
        _time = 0;
        _cooldownTimer = baseMaxCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        _cooldownTimer -= Time.deltaTime;

        if (_cooldownTimer <= 0)
        {
            Vector2 randomDirection = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f)).normalized;
            randomDirection *= spawnDistance;
            Vector3 spawnPosition = new Vector3(randomDirection.x, 0, randomDirection.y);
            Instantiate(enemyPrefab, spawnPosition, quaternion.identity);
            
            _cooldownTimer = Random.Range(0, baseMaxCooldown);
        }
    }
}
