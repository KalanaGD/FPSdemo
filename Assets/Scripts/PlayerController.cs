using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _cContoller;
    [SerializeField] private float _speed = 3.5f;

    private float _gravity = 9.81f;

    private void Awake()
    {
        _cContoller = GetComponent<CharacterController>();

    }//Awake

    private void Start()
    {
       
        Cursor.visible = false; //hide cursor
        Cursor.lockState = CursorLockMode.Locked; //lock cursor

    }//Start

    private void Update()
    {
        PlayerMove();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnLockCursor();
        }

    }//Update

    private void UnLockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }//UnLockCursor 


    private void PlayerMove()
    {
        Vector3 _direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 _velocity = _direction * _speed;
        
        _velocity.y -= _gravity; //Apply gravity

        _velocity = transform.transform.TransformDirection(_velocity);  //transform => local space to world space

        _cContoller.Move(_velocity * Time.deltaTime);

    }//PlayerMove
}
