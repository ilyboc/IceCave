using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class LeftHandTransformMapper : MonoBehaviour
{
    public ActionBasedController controller;

    private void Awake()
    {
        controller = GameObject.FindWithTag("LeftHandController")?.GetComponent<ActionBasedController>();
    }
    private void Start()
    {
        controller.positionAction.action.performed += OnPosition;
        controller.rotationAction.action.performed += OnRotation;
    }

    private void OnRotation(InputAction.CallbackContext obj)
    {
        transform.rotation = obj.ReadValue<Quaternion>();
    }

    private void OnPosition(InputAction.CallbackContext obj)
    {
        transform.position = obj.ReadValue<Vector3>();
    }

}
