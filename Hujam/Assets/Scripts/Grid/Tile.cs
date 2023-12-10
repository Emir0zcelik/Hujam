using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Tile
{
    public Building Building;
    public GameObject tileTypeGameObject;
    public TileType TileType;
    public bool isFull;
    
}

public enum TileType{Empty,Rock,Wood,Water}
