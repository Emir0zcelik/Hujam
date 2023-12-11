using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridManager))]
[RequireComponent(typeof(PlacementManager))]
public class PlacementManagerChecker : MonoBehaviour
{
    [SerializeField] private MeshFilter _basicMeshFilter;
    [SerializeField] private MeshRenderer _basicMeshRenderer;
    [SerializeField] private Transform _basicMeshTransform;

    public Material greenMat;
    public Material redMat;

    [SerializeField] private Camera _camera;

    private GridManager _gridManager;
    private PlacementManager _placementManager;
    private void Awake()
    {
        _gridManager = GetComponent<GridManager>();
        _placementManager = GetComponent<PlacementManager>();
    }

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 worldPosition = ray.GetPoint(distance);

            Vector2Int gridPosition = _gridManager.grid.WorldToGridPosition(worldPosition);
            gridPosition = _gridManager.grid.ClampBorders(gridPosition);
            Vector3 gridCenterWorldPosition = _gridManager.grid.GridToWorldPosition(gridPosition);

            _basicMeshTransform.position = gridCenterWorldPosition;
            _basicMeshFilter.sharedMesh = _placementManager.GetCurrentBuildingPrefab().GetComponent<MeshFilter>().sharedMesh;

            if (_gridManager.IsBuildingPlaceable(_placementManager.GetCurrentBuildingPrefab(), gridPosition))
            {
                _basicMeshRenderer.sharedMaterial = greenMat;
            }
            else
            {
                _basicMeshRenderer.sharedMaterial = redMat;
            }
        }
    }
}
