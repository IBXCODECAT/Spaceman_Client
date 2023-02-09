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

        [Header("Rotation")]
        [SerializeField] private float lookRate;

        [Header("UI Elements")]
        [SerializeField] private GameObject lookCursor;
        [SerializeField] private GameObject normalCursor;

        private Vector2 activeLookRate;

        // Update is called once per frame
        void Update()
        {
            if(VehicleInput.InCursorMode)
            {
                Vector2 mouseDistance = Vector2.zero;

                activeLookRate.x = VehicleInput.MouseInput.x;
                activeLookRate.y = VehicleInput.MouseInput.y;

                mouseDistance.x = (activeLookRate.x - VehicleInput.DisplayCenter.x) / VehicleInput.DisplayCenter.y;
                mouseDistance.y = (activeLookRate.y - VehicleInput.DisplayCenter.y) / VehicleInput.DisplayCenter.x;

                mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1);

                Vector3 cameraRotationEulers = new Vector3(-mouseDistance.y * lookRate * Time.deltaTime, mouseDistance.x * lookRate * Time.deltaTime, 0f);

                transform.localRotation = Quaternion.Euler(cameraRotationEulers + transform.localRotation.eulerAngles);
            }

            UpdateCursor();
        }

        private void UpdateCursor()
        {
            if(VehicleInput.InCursorMode)
            {
                Cursor.visible = false;

                normalCursor.SetActive(false);
                lookCursor.SetActive(true);
            }
            else
            {
                Cursor.visible = true;

                normalCursor.SetActive(true);
                lookCursor.SetActive(false);
            }
        }
    }
}
