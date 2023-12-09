using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _monster;
    private float spawnRate = 1.2f;
    private float InitialSpawnCount = 1f;
    private Timer timer;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer.currentTime += Mathf.Exp(Time.deltaTime);
            SpawnMonster();
        }
    }

    void SpawnMonster()
    {
        for (int i = 0; i < InitialSpawnCount * spawnRate * timer.currentTime; i++) 
        {
            Instantiate(_monster, Vector3.zero, Quaternion.identity);
        }
    }
}
