using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraManagement : MonoBehaviour
{
    [SerializeField] private float _borderSize = 100f;
    [SerializeField] private float _moveSpeed = 40f;
    private Vector3 _mousePosition;

    [SerializeField] private Vector2 minMaxX;
    [SerializeField] private Vector2 minMaxZ;

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 moveVector;

        if (mousePosition.x < _borderSize ||  mousePosition.x > Screen.width - _borderSize || mousePosition.y < _borderSize || mousePosition.y > Screen.height - _borderSize)
        {
            moveVector = GetMoveDirectionMouse(mousePosition);
        }
        else
        {
            moveVector = GetMoveDirectionKeyboard();
        }
        
        Move(moveVector);

    }

    private void Move(Vector3 moveVector)
    {
        transform.position += moveVector * (_moveSpeed * Time.deltaTime);

        transform.position = Extension.Clamp(transform.position , minMaxX,minMaxZ);
    }

    Vector3 GetMoveDirectionKeyboard()
    {
        Vector3 moveDirection = Vector3.zero;

        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");

        return moveDirection;
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

        if (mousePosition.z < _borderSize)
        {
            moveDirection.z = -1;
        }
        else if (mousePosition.z > Screen.height - _borderSize)
        {
            moveDirection.z = 1;
        }

        return moveDirection;
    }
}