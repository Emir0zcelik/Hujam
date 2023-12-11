using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKFootSolver : MonoBehaviour
{
    private Vector3 _lastPosition;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float distanceThreshold = 1;
    [SerializeField] private Transform _IKTarget;
    [SerializeField] private float heightMultiplier = 0.2f;

    private Transform _transform;

     [SerializeField] private float _lerpSpeed = 5;
    private float _lerp;

    private void Awake()
    {
        _transform = transform;
        _lastPosition = GetGroundPos();
        _IKTarget.transform.position = _lastPosition;
    }

    private void FixedUpdate()
    {
        Vector3 currentPos = GetGroundPos();

        if (Vector3.Distance(_lastPosition, currentPos) > distanceThreshold)
        {
            _lastPosition = currentPos;
            _lerp = 0;
        }
        
        _IKTarget.position = Vector3.Lerp(_IKTarget.position,_lastPosition,_lerp);
        //float height = (Mathf.Sin(_lerp) * heightMultiplier) + _lastPosition.y;
        //_IKTarget.position = new Vector3(_IKTarget.position.x, height, _IKTarget.position.z);
        _lerp += _lerpSpeed;
        _lerp = Mathf.Clamp(_lerp, 0, 1);
    }

    private Vector3 GetGroundPos()
    {
        if (Physics.Raycast(_transform.position, Vector3.down,out RaycastHit hitInfo,float.PositiveInfinity,_layerMask))
        {
            return hitInfo.point;
        }

        return Vector3.zero;
    }
}
