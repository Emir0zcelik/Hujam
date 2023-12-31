using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingData BuildingData;

    public void TakeDamage(int damage)
    {
        BuildingData.health -= damage;

        if(BuildingData.health <= 0)
            DestroyBuilding();
    }

    void DestroyBuilding()
    {
        Destroy(gameObject);
    }
}