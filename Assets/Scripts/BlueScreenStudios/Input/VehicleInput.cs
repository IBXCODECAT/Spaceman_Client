using UnityEngine;
using UnityEngine.InputSystem;

namespace BlueScreenStudios.Input
{
    public static class VehicleInput
    {
        public static InputActions VehicleInputActions { get; private set; }
        public static Vector2 DisplayCenter { get; private set; }
        public static Vector2 MouseInput { get; private set; }
        public static bool InCursorMode { get; private set; }



        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void VehicleInputInit()
        {
            //Set up Input System
            InputActions input = new InputActions();
            input.Vehicles.Enable();

            VehicleInputActions = input;

            DisplayCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

            Cursor.lockState = CursorLockMode.Confined;

            input.Vehicles.CursorModeKeyboardOnly.started += CursorMode_Started;
            input.Vehicles.CursorModeKeyboardOnly.canceled += CursorMode_Camceled;

            input.Vehicles.LookSteer.performed += LookInput;
        }

        private static void CursorMode_Started(InputAction.CallbackContext context)
        {
            InCursorMode = true;
        }

        private static void CursorMode_Camceled(InputAction.CallbackContext context)
        {
            InCursorMode = false;
        }

        private static void LookInput(InputAction.CallbackContext context)
        {
            MouseInput = context.ReadValue<Vector2>();
        }
    }
}
