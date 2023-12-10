using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NewBuilding",fileName = "NewBuilding")]
public class BuildingData : ScriptableObject
{
    public Building buildingPrefab;
    public int price;
    public BuildingData nextUpgradeBuildingData;
}
