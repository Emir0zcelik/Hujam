using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid<T>
{
    private float _cellSize;
    private Vector3 _worldOffset;

    private T[,] _grid;

    public T this[int x, int y]
    {
        get => _grid[x, y];
        set => _grid[x, y] = value;
    }
    public T this[Vector2Int gridPosition] 
    {
        get => _grid[gridPosition.x, gridPosition.y];
        set => _grid[gridPosition.x, gridPosition.y] = value;
    }

    public int GetLength(int dimension = 0)
    {
        return _grid.GetLength(dimension);
    }

    public void SetItem(Vector2Int gridPosition, T item)
    {
        _grid[gridPosition.x, gridPosition.y] = item;
    }

    public T GetItem(Vector2Int gridPosition)
    {
        return _grid[gridPosition.x, gridPosition.y];
    }

    public Grid(T[,] grid, float cellSize,Vector3 worldOffset = new Vector3())
    {
        _grid = grid;
        _cellSize = cellSize;
        _worldOffset = worldOffset;
    }

    public static Grid<T> CreateGridAtCenter(T[,] grid, float cellSize,Vector3 worldOffset = new Vector3())
    {
        Grid<T> firstGrid = new Grid<T>(grid, cellSize, worldOffset);
        Vector3 centerPosition = firstGrid.GetCenterPosition();
        Vector3 lowestWorldPosition = firstGrid.GridToWorldPosition(0, 0) - (new Vector3(1,0,1) * cellSize / 2);
        worldOffset = lowestWorldPosition - centerPosition;

        return new Grid<T>(grid, cellSize, worldOffset);

    }

    public Vector3 GridToWorldPosition(Vector2Int gridPosition)
    {
        return GridToWorldPosition(gridPosition.x, gridPosition.y);
    }

    public Vector3 GridToWorldPosition(int x, int y)
    {
        Vector3 tileCorner = new Vector3(x, 0, y) * _cellSize;
        Vector3 tileHalf = (new Vector3(1, 0, 1) * _cellSize) / 2;
        return tileCorner + tileHalf + _worldOffset;
    }

    public Vector2Int WorldToGridPosition(Vector3 worldPosition)
    {
        worldPosition = worldPosition - _worldOffset;
        
        int x = Mathf.FloorToInt(worldPosition.x / _cellSize);
        int y = Mathf.FloorToInt(worldPosition.z / _cellSize);

        return new Vector2Int(x, y);
    }

    public Vector2Int ClampBorders(Vector2Int gridPosition)
    {
        return new Vector2Int(Mathf.Clamp(gridPosition.x, 0, _grid.GetLength(0) - 1),
            Mathf.Clamp(gridPosition.y, 0, _grid.GetLength(1) - 1));
    }

    public bool IsValidPosition(int x, int y)
    {
        return x >= 0 && y >= 0 && x < _grid.GetLength(0) && y < _grid.GetLength(1);
    }

    public Vector3 GetCenterPosition()
    {
        int gridLengthX = _grid.GetLength(0) - 1;
        int gridLengthY = _grid.GetLength(1) - 1;
        
        Vector3 highestWorldPosition = GridToWorldPosition(gridLengthX, gridLengthY) + new Vector3(1,0,1) * (_cellSize / 2);
        Vector3 lowestWorldPosition = GridToWorldPosition(0, 0) - new Vector3(1,0,1) * (_cellSize / 2);
        
        return lowestWorldPosition + ((highestWorldPosition - lowestWorldPosition) / 2);
    }
}
