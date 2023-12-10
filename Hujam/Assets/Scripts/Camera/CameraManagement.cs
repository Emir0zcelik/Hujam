using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraManagement : MonoBehaviour
{
    [SerializeField] private float _borderSize = 100f;
    [SerializeField] private float _moveSpeed = 40f;
    private Vector3 _mousePosition;
    Vector3 _moveDirection;

    [SerializeField] private Vector3 minMax;

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;


        if (mousePosition.x < _borderSize || mousePosition.x > Screen.width - _borderSize || mousePosition.y < _borderSize || mousePosition.y > Screen.height - _borderSize)
        {
            _moveDirection = GetMoveDirection(mousePosition);
        }
        else
        {
            _moveDirection = GetMoveDirection();
        }

        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);

        transform.position = Extension.Clamp(transform.position , minMax);

    }


    Vector3 GetMoveDirection(Vector3 moveVector)
    {
        Vector3 moveDirection = Vector3.zero;

        if (mousePosition.x < _borderSize)
        {
            moveDirection.x = -1;
        }
        else if (mousePosition.x > Screen.width - _borderSize)
        {
            moveDirection.x = 1;
        }

        if (mousePosition.z < _borderSize)
        {
            moveDirection.z = -1;
        }
        else if (mousePosition.z > Screen.height - _borderSize)
        {
            moveDirection.z = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.z = -1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.z = 1;
        }

        return moveDirection;
    }
}
