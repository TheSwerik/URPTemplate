using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputForCamera : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] private float lookSpeed = 0.5f;
    [SerializeField] private bool invertY = false;
    [SerializeField] private bool turnPlayer = true;

    private CinemachinePOV _aimPov;
    private CinemachineFreeLook _freeLook;
    private Transform _player;

    private void Awake()
    {
        _aimPov = GetComponentInChildren<CinemachinePOV>();
        _freeLook = GetComponentInChildren<CinemachineFreeLook>();
        _player = transform.parent;
    }

    private void OnEnable() { Cursor.visible = false; }
    private void OnDisable() { Cursor.visible = true; }

    public void OnLookFirstPerson(InputAction.CallbackContext context)
    {
        if (!enabled) return;

        var lookMovement = context.ReadValue<Vector2>().normalized;

        // Rotate Camera Vertically:
        if (invertY) lookMovement.y = -lookMovement.y;
        lookMovement.y *= 70f;
        _aimPov.m_VerticalAxis.Value += lookMovement.y * lookSpeed * Time.deltaTime;

        // Rotate Player Horizontally
        lookMovement.x *= 180f;
        if (turnPlayer) _player.Rotate(Vector3.up, lookMovement.x * lookSpeed * Time.deltaTime);
        else _aimPov.m_HorizontalAxis.Value += lookMovement.x * lookSpeed * Time.deltaTime;
    }

    public void OnLookThirdPerson(InputAction.CallbackContext context)
    {
        if (!enabled) return;

        var lookMovement = context.ReadValue<Vector2>().normalized;

        // Rotate Camera Vertically:
        if (invertY) lookMovement.y = -lookMovement.y;
        _freeLook.m_YAxis.Value += lookMovement.y * lookSpeed * Time.deltaTime;

        // Rotate Player Horizontally
        lookMovement.x *= 180f;
        _freeLook.m_XAxis.Value += lookMovement.x * lookSpeed * Time.deltaTime;
        if (turnPlayer) _player.Rotate(Vector3.up, lookMovement.x * lookSpeed * Time.deltaTime);
    }
}