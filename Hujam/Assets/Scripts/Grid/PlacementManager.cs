using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridManager))]
public class PlacementManager : MonoBehaviour
{
    [SerializeField] private Building currentBuildingPrefab;
    [SerializeField] private GridManager _gridManager;

    [SerializeField] private Camera _camera;

    private void Awake()
    {
        _gridManager = GetComponent<GridManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && !Extension.IsPointerOverUIObject())
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            if (plane.Raycast(ray, out float distance))
            {
                Vector3 worldPosition = ray.GetPoint(distance);
                Vector2Int gridPosition = _gridManager.grid.WorldToGridPosition(worldPosition);
                gridPosition = _gridManager.grid.ClampBorders(gridPosition);
                worldPosition = _gridManager.grid.GridToWorldPosition(gridPosition);

                TrySpawnBuilding(currentBuildingPrefab, worldPosition);
            }
        }
    }

    private bool TrySpawnBuilding(Building buildingPrefab,Vector3 worldPosition)
    {
        if (!_gridManager.IsBuildingPlaceable(buildingPrefab, worldPosition))
            return false;

        if (PlayerStats.money < buildingPrefab.BuildingData.price)
            return false;
        
        SpawnBuilding(buildingPrefab,worldPosition);
        return true;
    }

    private void SpawnBuilding(Building buildingPrefab,Vector3 worldPosition)
    {
        Building instantiatedBuilding = Instantiate(buildingPrefab);

        PlayerStats.money -= buildingPrefab.BuildingData.price;

        _gridManager.TryPlaceBuilding(instantiatedBuilding, worldPosition);
    }

    public void ChangeCurrentBuildingPrefab(Building building)
    {
        currentBuildingPrefab = building;
    }
    
    public Building GetCurrentBuildingPrefab()
    {
        return currentBuildingPrefab;
    }
}
