using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

namespace BlueScreenStudios.Input
{
    public static class DeviceActions
    {
        /// <summary>
        /// Sets the lightbar color on dualshock controllers
        /// </summary>
        /// <param name="color">The color to set the lightbar to</param>
        public static void SetDualshockLEDColor(Color color)
        {
            DualShockGamepad gamepad = (DualShockGamepad)Gamepad.current;

            if(gamepad != null)
            {
                gamepad.SetLightBarColor(color);
            }
        }

        /// <summary>
        /// Vibrates the current gamepad controller
        /// </summary>
        [RuntimeInitializeOnLoadMethod]
        public static void VibrateController()
        {
            Gamepad gamepad = Gamepad.current;

            if(gamepad != null)
            {
                gamepad.SetMotorSpeeds(0.123f, 0.234f);
            }
        }
    }
}
