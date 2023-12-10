using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridManager))]
public class PlacementManager : MonoBehaviour
{
    [SerializeField] private List<BuildingData> buildingDataList;
    [SerializeField] private GridManager _gridManager;

    private void Awake()
    {
        _gridManager = GetComponent<GridManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Spawn
}
