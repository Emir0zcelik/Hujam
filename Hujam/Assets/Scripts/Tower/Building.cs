using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Building : MonoBehaviour, IDamagable
{
    public BuildingData BuildingData;
    public float health;
    [FormerlySerializedAs("GridManager")] public GridManager gridManager;

    private bool _isDead = false;

    public void TakeDamage(float damage)
    {

        if (_isDead)
            return; 
        
        health -= damage;

        if (health <= 0)
        {
            _isDead = true;
            DestroyBuilding();
        }
    }

    void DestroyBuilding()
    {
        if(gridManager != null)
            gridManager.TryRemoveBuilding(transform.position, out Building building);
        
        Destroy(gameObject);
    }
}