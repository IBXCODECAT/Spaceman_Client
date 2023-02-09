using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using BlueScreenStudios.Input;

namespace BlueScreenStudios.Vehicles
{
    public class VehicleCamera : MonoBehaviour
    {
        [SerializeField] private Camera vehicleCamera;

        private bool cursorMode;

        private void Start()
        {
            InputActions input = VehicleInput.VehicleInputActions;

            input.Vehicles.CursorModeKeyboardOnly.started += CursorMode_Started;
            input.Vehicles.CursorModeKeyboardOnly.canceled += CursorMode_Camceled;
        }

        private void CursorMode_Started(InputAction.CallbackContext context)
        {
            cursorMode = true;
        }

        private void CursorMode_Camceled(InputAction.CallbackContext context)
        {
            cursorMode = false;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
