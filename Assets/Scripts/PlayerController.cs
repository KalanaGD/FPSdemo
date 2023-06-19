using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }//Avake

    private void Update()
    {
        CalculateMovement();
    }//Update

    private void CalculateMovement()
    {
        Vector3 _direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 _velocity = _direction * _speed;

        _characterController.Move(_velocity * Time.deltaTime);
    }//CalculateMovement
}
