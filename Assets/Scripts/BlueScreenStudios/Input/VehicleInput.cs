using UnityEngine;

namespace BlueScreenStudios.Input
{
    public static class VehicleInput
    {
        public static InputActions VehicleInputActions { get; private set; }

        private static void OnEnable()
        {
            VehicleInputInit();
        }

        public static void VehicleInputInit()
        {
            //Set up Input System
            InputActions input = new InputActions();
            input.Vehicles.Enable();

            VehicleInputActions = input;

            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
