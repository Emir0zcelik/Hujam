using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "NewBuilding",fileName = "NewBuilding")]
public class BuildingData : ScriptableObject
{
    public float health;
    public int price;
    public Building nextUpgradeBuilding;
    public List<TileType> placeableTileTypeList;
}
