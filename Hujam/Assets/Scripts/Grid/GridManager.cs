using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private Grid<Tile> _grid;

    public GameObject tilePrefab;
    
    

    private void Awake()
    {
        _grid = Grid<Tile>.CreateGridAtCenter(new Tile[500, 500], 1);

        for (int x = 0; x < _grid.GetLength(0); x++)
        {
            for (int y = 0; y < _grid.GetLength(1); y++)
            {
                Instantiate(tilePrefab, _grid.GridToWorldPosition(x, y), Quaternion.identity);
            }
        }
    }

    public bool IsFull(int x, int y)
    {
        return _grid[x, y].isFull;
    }
    
    public bool IsFull(Vector2Int gridPosition)
    {
        return IsFull(gridPosition.x, gridPosition.y);
    }

    public bool IsFull(Vector3 worldPosition)
    {
        Vector2Int gridPosition = _grid.WorldToGridPosition(worldPosition);
        return IsFull(gridPosition);
    }

    public void PlaceBuilding(Vector2Int,Building building)
    {
        
    }
    
}
