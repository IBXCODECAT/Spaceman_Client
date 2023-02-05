using BlueScreenStudios.Input;
using UnityEngine;
using UnityEngine.InputSystem;

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

        [Header("Effects")]
        [SerializeField] TrailRenderer[] afterburnerTrails;

        private float activeForwardSpeed = 1f;
        private float activeStrafeSpeed = 1f;
        private float activeHoverSpeed = 1f;

        private float activeRollRate;

        private Vector2 activeLookRate;
        private Vector2 displayCenter;
        private Vector2 mouseDistance;

        private void Awake()
        {
            displayCenter.x = Screen.width * 0.5f;
            displayCenter.y = Screen.height * 0.5f;

            Cursor.lockState = CursorLockMode.Confined;

            //Set up Input System
            InputActions input = new InputActions();
            input.Vehicles.Enable();

            //Subscribe to InputSystem "Performed" events
            input.Vehicles.Steering.performed += Steering_Applied;
            input.Vehicles.Thrust.performed += Thrust_Applied;
            input.Vehicles.Roll.performed += Roll_Performed;

            //Subscribe to InputSystem "Cancelled" Events
            input.Vehicles.Thrust.canceled += Thrust_canceled;
            input.Vehicles.Roll.canceled += Roll_canceled;
        }

        //Input Variables set by the Input C# Events
        private Vector2 steeringInputVector;
        private Vector2 thrustInputVector;
        private float rollInputFloat;

        private void Steering_Applied(InputAction.CallbackContext context)
        {
            steeringInputVector = context.ReadValue<Vector2>();
        }

        private void Thrust_Applied(InputAction.CallbackContext context)
        {
            thrustInputVector = context.ReadValue<Vector2>();
        }

        private void Thrust_canceled(InputAction.CallbackContext obj)
        {
            thrustInputVector = Vector2.zero;
        }

        private void Roll_Performed(InputAction.CallbackContext context)
        {
            rollInputFloat = context.ReadValue<float>();
        }

        private void Roll_canceled(InputAction.CallbackContext obj)
        {
            rollInputFloat = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            activeLookRate.x = steeringInputVector.x;
            activeLookRate.y = steeringInputVector.y;

            mouseDistance.x = (activeLookRate.x - displayCenter.x) / displayCenter.y;
            mouseDistance.y = (activeLookRate.y - displayCenter.y) / displayCenter.x;

            mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1);

            activeRollRate = Mathf.Lerp(activeRollRate, rollInputFloat, rollAceleration * Time.deltaTime);

            transform.Rotate(-mouseDistance.y * lookRate * Time.deltaTime, mouseDistance.x * lookRate * Time.deltaTime, activeRollRate * rollRate * Time.deltaTime, Space.Self);

            activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, thrustInputVector.y * forwardSpeed, forwardAceleration * Time.deltaTime);
            activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, thrustInputVector.x * strafeSpeed, strafeAceleration * Time.deltaTime);
            //activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxis("Hover") * hoverSpeed, hoverAceleration * Time.deltaTime);

            transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
            transform.position += transform.right * activeStrafeSpeed * Time.deltaTime;

            if (thrustInputVector.y > 0.1f)
            {
                foreach (TrailRenderer trail in afterburnerTrails)
                {
                    trail.enabled = true;
                }
            }
            else
            {
                foreach (TrailRenderer trail in afterburnerTrails)
                {
                    trail.enabled = false;
                }
            }
        }
    }
}
