using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField]private float _sensitivity = 3.5f;

    void Start()
    {
        
    }

    private void Update()
    {
        CalculateMouseX();

    }

    private void CalculateMouseX()
    {
        float _mouseX = Input.GetAxis("Mouse X");

        Vector3 _newRotation = transform.localEulerAngles;
        _newRotation.y += _mouseX * _sensitivity;

        transform.localEulerAngles = _newRotation;

    }//CalculateMouseX
}
