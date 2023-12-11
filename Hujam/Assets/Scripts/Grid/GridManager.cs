using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Grid<Tile> grid { get; private set; }

    
    

    private void Awake()
    {
        grid = Grid<Tile>.CreateGridAtCenter(new Tile[250, 250], 1);
        
    }

    private bool IsFull(int x, int y)
    {
        return grid[x, y].isFull;
    }
    
    public bool IsFull(Vector2Int gridPosition)
    {
        return IsFull(gridPosition.x, gridPosition.y);
    }

    public bool IsFull(Vector3 worldPosition)
    {
        Vector2Int gridPosition = grid.WorldToGridPosition(worldPosition);
        return IsFull(gridPosition);
    }

    private void PlaceBuilding(Building building ,Vector2Int gridPosition)
    {
        Tile tile = grid[gridPosition];

        tile.Building = building;
        tile.isFull = true;

        building.transform.position = grid.GridToWorldPosition(gridPosition);
        grid[gridPosition] = tile;
    }

    public bool TryPlaceBuilding(Building building,Vector2Int gridPosition)
    {
        Tile tile = grid[gridPosition];

        if (!IsBuildingPlaceable(building, gridPosition))
            return false;

        PlaceBuilding(building,gridPosition);

        return true;
    }

    public bool IsBuildingPlaceable(Building building,Vector2Int gridPosition)
    {
        Tile tile = grid[gridPosition];
        
        if (tile.isFull)
            return false;

        if (!building.BuildingData.placeableTileTypeList.Contains(tile.TileType))
            return false;

        return true;
    }
    
    public bool IsBuildingPlaceable(Building building,Vector3 worldPosition)
    {
        Vector2Int gridPosition = grid.WorldToGridPosition(worldPosition);
        Debug.Log(gridPosition);
        return IsBuildingPlaceable(building, gridPosition);
    }

    public bool TryPlaceBuilding(Building building, Vector3 worldPosition)
    {
        Vector2Int gridPosition = grid.WorldToGridPosition(worldPosition);
        return TryPlaceBuilding(building, gridPosition);
    }

    private Building RemoveBuilding(Vector2Int gridPosition)
    {
        Tile tile = grid[gridPosition];
        Building buildingToReturn = tile.Building;
        
        tile.Building = null;
        tile.isFull = false;
        
        return buildingToReturn;
    }

    public bool TryRemoveBuilding(Vector2Int gridPosition, out Building building)
    {
        building = null;
        
        if (!grid[gridPosition].isFull)
            return false;

        building = RemoveBuilding(gridPosition);
        return true;
    }

    public bool TryRemoveBuilding(Vector3 worldPosition, out Building building)
    {
        Vector2Int gridPosition = grid.WorldToGridPosition(worldPosition);
        return TryRemoveBuilding(gridPosition, out building);
    }
    
    
    
}
