﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Joystick _joystick;
    public float _moveSpeed;
    private Transform _cameraTransform;
    private Rigidbody _rigidbody;

    void Start()
    {
        _cameraTransform = transform.GetChild(0);
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 forward = new Vector3(_cameraTransform.forward.x, 0, _cameraTransform.forward.z);
        forward.Normalize();
        Vector3 right = Vector3.Cross(forward, new Vector3(0, 1, 0));
        forward *= _joystick.Vertical * _moveSpeed;
        right *= _joystick.Horizontal * _moveSpeed;
        _rigidbody.velocity = forward - right;
    }
}