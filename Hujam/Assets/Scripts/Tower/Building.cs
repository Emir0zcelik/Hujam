using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingData BuildingData;

    public void TakeDamage(float damage)
    {
        BuildingData.health -= damage;

        if (BuildingData.health <= 0)
        {
            DestroyBuilding();
        }
    }

    void DestroyBuilding()
    {
        Destroy(gameObject);
    }
}