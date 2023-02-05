using UnityEngine;

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


        private void Start()
        {
            displayCenter.x = Screen.width * 0.5f;
            displayCenter.y = Screen.height * 0.5f;

            Cursor.lockState = CursorLockMode.Confined;

        }
        // Update is called once per frame
        void Update()
        {
            activeLookRate.x = Input.mousePosition.x;
            activeLookRate.y = Input.mousePosition.y;

            mouseDistance.x = (activeLookRate.x - displayCenter.x) / displayCenter.y;
            mouseDistance.y = (activeLookRate.y - displayCenter.y) / displayCenter.x;

            mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1);

            activeRollRate = Mathf.Lerp(activeRollRate, Input.GetAxisRaw("Roll"), rollAceleration * Time.deltaTime);

            transform.Rotate(-mouseDistance.y * lookRate * Time.deltaTime, mouseDistance.x * lookRate * Time.deltaTime, activeRollRate * rollRate * Time.deltaTime, Space.Self);

            activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxis("Vertical") * forwardSpeed, forwardAceleration * Time.deltaTime);
            activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxis("Horizontal") * strafeSpeed, strafeAceleration * Time.deltaTime);
            //activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxis("Hover") * hoverSpeed, hoverAceleration * Time.deltaTime);

            transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
            transform.position += transform.right * activeStrafeSpeed * Time.deltaTime;

            if (Input.GetAxis("Vertical") > 0.1f)
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
