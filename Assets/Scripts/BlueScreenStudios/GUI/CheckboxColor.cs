using UnityEngine;
using UnityEngine.UI;

namespace BlueScreenStudios.GUI
{
    public class CheckboxColor : MonoBehaviour
    {
        [SerializeField] private Color checkboxEnabledColor;
        [SerializeField] private Color checkboxDisabledColor;
        [SerializeField] private Toggle[] toggles;

        private void Start()
        {
            foreach(Toggle toggle in toggles) 
            {
                toggle.onValueChanged.AddListener(OnToggleValueChanged);
            }

            OnToggleValueChanged(false);
        }

        private void OnToggleValueChanged(bool isOn)
        {
            foreach(Toggle toggle in toggles)
            {
                toggle.image.color = toggle.isOn ? checkboxEnabledColor : checkboxDisabledColor;
            }
        }
    }
}
