using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BlueScreenStudios.GUI
{
    public class ToggleGameObjectButton : MonoBehaviour
    {
        public GameObject ObjectToToggle;
        public bool ResetSelectionAfterClick;

        void Update()
        {
            if (ObjectToToggle.activeSelf && Input.GetButtonDown(GameConstants.k_ButtonNameCancel))
            {
                SetGameObjectActive(false);
            }
        }

        public void SetGameObjectActive(bool active)
        {
            ObjectToToggle.SetActive(active);

            if (ResetSelectionAfterClick)
                EventSystem.current.SetSelectedGameObject(null);
        }
    }
}