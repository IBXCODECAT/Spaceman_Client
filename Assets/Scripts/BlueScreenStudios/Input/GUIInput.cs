using UnityEngine;
using UnityEngine.InputSystem;

namespace BlueScreenStudios.Input
{
    public static class GUIInput
    {
        public static InputActions GUIInputActions { get; private set; }
        public static Vector2 MouseInput { get; private set; }
        public static bool InCursorMode { get; private set; }



        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void GUIInputInit()
        {
            //Set up Input System
            InputActions input = new InputActions();
            input.GUI.Enable();

            GUIInputActions = input;

            Cursor.lockState = CursorLockMode.None;

            input.GUI.Point.performed += UpdatePointerPosition;
        }

        private static void UpdatePointerPosition(InputAction.CallbackContext context)
        {
            MouseInput = context.ReadValue<Vector2>();
        }
    }
}
