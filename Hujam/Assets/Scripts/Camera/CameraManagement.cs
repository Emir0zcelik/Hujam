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

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;


        if (mousePosition.x < _borderSize || mousePosition.x > Screen.width - _borderSize || mousePosition.y < _borderSize || mousePosition.y > Screen.height - _borderSize)
        {
            _moveDirection = GetMoveDirectionMouse(mousePosition);
        }
        else
        {
            _moveDirection = GetMoveDirectionKeyboard();
        }

        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);
    }

    Vector3 GetMoveDirectionKeyboard()
    {
        Vector3 moveDirection = Vector3.zero;
        
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
            moveDirection.y = -1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y = 1;
        }

        return moveDirection.normalized;
    }

    Vector3 GetMoveDirectionMouse(Vector3 mousePosition)
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

        if (mousePosition.y < _borderSize)
        {
            moveDirection.y = -1;
        }
        else if (mousePosition.y > Screen.height - _borderSize)
        {
            moveDirection.y = 1;
        }

        return moveDirection;
    }
}
