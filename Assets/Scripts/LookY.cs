using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 3.5f;
  
    void Start()
    {
        
    }

    void Update()
    {
        CalculateMouseY();

    }

    private void CalculateMouseY()
    {
        float _mouseY = Input.GetAxis("Mouse Y");

        Vector3 _newRotation = transform.localEulerAngles;
        _newRotation.x -= _mouseY * _sensitivity;

        transform.localEulerAngles = _newRotation;
    }
}
