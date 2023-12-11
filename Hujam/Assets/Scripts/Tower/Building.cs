using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, IDamagable
{
    public BuildingData BuildingData;
    public GridManager gridManager;
    public float health;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            DestroyBuilding();
        }
    }

    void DestroyBuilding()
    {
        gridManager.TryRemoveBuilding(transform.position, out Building building);
        Destroy(gameObject);
    }
}