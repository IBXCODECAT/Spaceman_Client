using BlueScreenStudios.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

namespace BlueScreenStudios.Vehicles
{
    public class SpaceshipController : MonoBehaviour
    {
        [Header("Speeds")]
        [SerializeField] private float forwardSpeed;
        [SerializeField] private float strafeSpeed;
        [SerializeField] private float hoverSpeed;

        [Header("Acelerations/Lerps")]
        [SerializeField] private float forwardAceleration;
        [SerializeField] private float strafeAceleration;
        [SerializeField] private float hoverAceleration;

        [Header("Rotation")]
        [SerializeField] private float lookRate;

        [Header("Rolls")]
        [SerializeField] private float rollRate;
        [SerializeField] private float rollAceleration;

        [Header("Visual Effects")]
        [SerializeField] private float effectTriggerThreshold;
        [SerializeField] private float afterburnerTime;
        [SerializeField] private VisualEffect[] afterburnerVFX;
        [SerializeField] private Light[] afterburnerLights;

        [Header("Audio")]
        [SerializeField] private AudioSource afterburnerAudiosource;

        private float activeForwardSpeed = 1f;
        private float activeStrafeSpeed = 1f;
        private float activeHoverSpeed = 1f;

        private float activeRollRate;

        private Vector2 activeLookRate;
        private Vector2 mouseDistance;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Confined;

            //Set up Input System
            InputActions input = VehicleInput.VehicleInputActions;

            //Subscribe to InputSystem "Performed" events
            input.Vehicles.Thrust.performed += Thrust_Applied;
            input.Vehicles.Roll.performed += Roll_Performed;

            //Subscribe to InputSystem "Cancelled" Events
            input.Vehicles.Thrust.canceled += Thrust_canceled;
            input.Vehicles.Roll.canceled += Roll_canceled;
        }

        //Input Variables set by the Input C# Events
        private Vector2 thrustInputVector;
        private float rollInputFloat;

        private void Thrust_Applied(InputAction.CallbackContext context)
        {
            thrustInputVector = context.ReadValue<Vector2>();
        }

        private void Thrust_canceled(InputAction.CallbackContext context)
        {
            thrustInputVector = Vector2.zero;
        }

        private void Roll_Performed(InputAction.CallbackContext context)
        {
            rollInputFloat = context.ReadValue<float>();
        }

        private void Roll_canceled(InputAction.CallbackContext context)
        {
            rollInputFloat = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (!VehicleInput.InCursorMode)
            {
                activeLookRate.x = VehicleInput.MouseInput.x;
                activeLookRate.y = VehicleInput.MouseInput.y;

                mouseDistance.x = (activeLookRate.x - VehicleInput.DisplayCenter.x) / VehicleInput.DisplayCenter.y;
                mouseDistance.y = (activeLookRate.y - VehicleInput.DisplayCenter.y) / VehicleInput.DisplayCenter.x;

                mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1);

                activeRollRate = Mathf.Lerp(activeRollRate, rollInputFloat, rollAceleration * Time.deltaTime);

                transform.Rotate(-mouseDistance.y * lookRate * Time.deltaTime, mouseDistance.x * lookRate * Time.deltaTime, activeRollRate * rollRate * Time.deltaTime, Space.Self);
            }

            activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, thrustInputVector.y * forwardSpeed, forwardAceleration * Time.deltaTime);
            activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, thrustInputVector.x * strafeSpeed, strafeAceleration * Time.deltaTime);
            //activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxis("Hover") * hoverSpeed, hoverAceleration * Time.deltaTime);

            transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
            transform.position += transform.right * activeStrafeSpeed * Time.deltaTime;

            UpdateAfterBurnerVFX();
        }

        /// <summary>
        /// Updates the afterburner VFX to reflect the current input
        /// </summary>
        private void UpdateAfterBurnerVFX()
        {
            if(thrustInputVector.y > effectTriggerThreshold)
            {
                foreach(VisualEffect effect in afterburnerVFX)
                {
                    effect.SetFloat("Time Alive", thrustInputVector.y * afterburnerTime);
                    effect.enabled = true;
                }

                foreach(Light light in afterburnerLights)
                {
                    light.intensity = thrustInputVector.y;
                }
            }
            else
            {
                foreach(VisualEffect effect in afterburnerVFX)
                {
                    effect.SetFloat("Time Alive", 0f);
                    effect.enabled = false;
                }

                foreach(Light light in afterburnerLights)
                {
                    light.intensity = 0;
                }
            }
        }
    }
}
