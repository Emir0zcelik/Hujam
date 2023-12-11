using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[RequireComponent(typeof(GridManager))]
public class WorldGenerator : MonoBehaviour
{
    private GridManager _gridManager;

    public GameObject rockPrefab;
    public int rockChance = 250;
    [FormerlySerializedAs("basePrefab")] public Building mainBasePrefab;
    
    private void Awake()
    {
        _gridManager = GetComponent<GridManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //World zero
        Vector2Int zeroGridPosition = _gridManager.grid.WorldToGridPosition(Vector3.zero);
        Building instantiatedBaseBuilding = Instantiate(mainBasePrefab, _gridManager.grid.GridToWorldPosition(zeroGridPosition), Quaternion.identity);
        _gridManager.TryPlaceBuilding(instantiatedBaseBuilding, zeroGridPosition);
        
        for (int x = 0; x < _gridManager.grid.GetLength(0); x++)
        {
            for (int y = 0; y < _gridManager.grid.GetLength(1); y++)
            {
                if (Random.Range(0, rockChance) == 0 && _gridManager.grid[x,y].TileType == TileType.Empty)
                {
                   Tile tile =  _gridManager.grid[x, y];
                   tile.TileType = TileType.Rock;
                   tile.tileTypeGameObject = Instantiate(rockPrefab, _gridManager.grid.GridToWorldPosition(x, y), Quaternion.identity);
                   _gridManager.grid[x, y] = tile;
                }
            }
        }
    }

   
}
