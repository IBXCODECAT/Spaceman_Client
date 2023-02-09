//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/BlueScreenStudios/Input/Input.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace BlueScreenStudios.Input
{
    public partial class @InputActions : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Vehicles"",
            ""id"": ""80cea9f7-cde6-4c81-ac79-ee1a207274f6"",
            ""actions"": [
                {
                    ""name"": ""Thrust"",
                    ""type"": ""Value"",
                    ""id"": ""65cf1920-5385-484d-9c38-ae114f896a2b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Hover"",
                    ""type"": ""Value"",
                    ""id"": ""f1890e41-0101-4b9a-afd4-cb21a8052db0"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Value"",
                    ""id"": ""45f51caa-ed77-476d-a6da-2e06354701e6"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look/Steer"",
                    ""type"": ""Value"",
                    ""id"": ""a893e93a-aae0-4dc4-afd7-d761b9432701"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""ca73c0b1-7510-44a2-8d21-8d0108cba913"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cursor Mode (Keyboard Only)"",
                    ""type"": ""Button"",
                    ""id"": ""ce016cff-ad9f-49b1-9889-888f75bce8c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3b374c73-27e9-42bf-b69e-6e2f94981991"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""309d1c0a-d829-4b7b-9588-a4d47caf5219"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""GamePad"",
                    ""id"": ""c7a9e739-5a0b-469f-94b1-79a4648d45b4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""58ed6f6a-a07a-47cb-b014-f58bbf440e51"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9c7e1092-774e-48c6-a419-a19ffbce34b3"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""4abdd1cc-291e-4a74-a326-420d4d04a932"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""913ca854-5422-43dc-a08c-e35c1d7768c9"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0e7a12a8-ffa0-442d-8101-b88d4b3eb22f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad 2D Vector"",
                    ""id"": ""ae5d57fa-72d2-4489-8e50-b24d19dd94a9"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""af9810b6-3f0f-4f10-aefb-4ee3aead75a9"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fcc6ec7e-9918-4be0-af58-7f4d56d4fc5b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""562f4894-f8fe-4fec-872b-2e94a0df081e"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2e82f8cf-a57a-4790-9d3f-dc5f2eb973bc"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard 2D Vector"",
                    ""id"": ""681d0ce4-799f-480b-bad5-e6ba4a5f5805"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7d4a797c-5c23-46cc-9786-de063a4390fa"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4fec0cc7-ba15-4448-bcd8-912f0d663707"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""07b6dff2-4e01-40bf-948a-07e4ea1bc6e5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""af3184c8-2664-4589-afd0-875780a80f9b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""07361cda-b916-4797-8ea2-39addf9d0053"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Cursor Mode (Keyboard Only)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""906e5d5a-0b8d-4eac-8886-8049129cc660"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Look/Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Gamepad 2D Vector"",
                    ""id"": ""5daca83c-97b3-4def-acb5-e9ac4e71c20a"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2"",
                    ""groups"": """",
                    ""action"": ""Look/Steer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""42fb0a05-0714-4e25-8fc3-f438da4f2346"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look/Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""599d7e94-32bb-4453-837f-553b9804f984"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look/Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9d55d942-71da-4a6e-958b-c0f1528a30e1"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look/Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6f2fc8c3-c601-4bfa-9e7d-06362f3fda9c"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look/Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""da29530c-2a4f-4e42-befb-166a9c1de596"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hover"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b3c5b22c-b0d9-4fe2-bf0e-c84709bd7f2a"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Hover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6a96ee70-e8d3-4571-a84b-f91f1327ff56"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Hover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""4054b39f-9fac-494f-93b5-3c9b0f09d3d8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hover"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""904f58bf-33b1-485f-81b9-1e941921ca71"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Hover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""28f7b3d3-e07b-4fca-8eb6-f58cbf0f6f93"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Hover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""GUI"",
            ""id"": ""9fd36618-6808-4296-9fe3-afbf33fc9c1e"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""84e2647f-d6d7-4d69-8bd2-d030cece3804"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""6c6dc4e4-4b22-4480-862f-7afdf0db1ddd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""20d95728-09c5-4138-8adc-237e4d05d3e3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""973db9d6-1762-4900-9219-5f078170abce"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""350e4ed8-33d1-454b-9217-b7390300f4b9"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b31f2cc4-24d6-41c0-aefa-80aa0f8de98a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8eaf3a5-2a33-460e-97c1-6aeea18fc934"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Gamepad 2D Vector"",
                    ""id"": ""e25b4ce8-a991-4308-bf56-74fe528958e6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e700b3ce-b871-4bd0-b015-08dcf1478237"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c3d720a5-d397-4adc-a5c3-97db5541ffc5"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""01773ad8-6283-4565-acb4-e02864f9e629"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""81c59fad-f833-4c48-9863-678d8519c027"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard 2D Vector"",
                    ""id"": ""cb9dfebf-3dae-48d9-9acf-71f00695aa04"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d758cb34-b5bf-48d9-b68a-ed36d4edd109"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5f5d3a0d-35a6-4bbb-a08e-48830059746a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""93f67fdb-ba42-4da2-aebb-11b92e428bdc"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""60209ac7-094b-45be-b142-e6214e9876e0"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Vehicles
            m_Vehicles = asset.FindActionMap("Vehicles", throwIfNotFound: true);
            m_Vehicles_Thrust = m_Vehicles.FindAction("Thrust", throwIfNotFound: true);
            m_Vehicles_Hover = m_Vehicles.FindAction("Hover", throwIfNotFound: true);
            m_Vehicles_Roll = m_Vehicles.FindAction("Roll", throwIfNotFound: true);
            m_Vehicles_LookSteer = m_Vehicles.FindAction("Look/Steer", throwIfNotFound: true);
            m_Vehicles_Fire = m_Vehicles.FindAction("Fire", throwIfNotFound: true);
            m_Vehicles_CursorModeKeyboardOnly = m_Vehicles.FindAction("Cursor Mode (Keyboard Only)", throwIfNotFound: true);
            // GUI
            m_GUI = asset.FindActionMap("GUI", throwIfNotFound: true);
            m_GUI_Pause = m_GUI.FindAction("Pause", throwIfNotFound: true);
            m_GUI_Select = m_GUI.FindAction("Select", throwIfNotFound: true);
            m_GUI_Navigate = m_GUI.FindAction("Navigate", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Vehicles
        private readonly InputActionMap m_Vehicles;
        private IVehiclesActions m_VehiclesActionsCallbackInterface;
        private readonly InputAction m_Vehicles_Thrust;
        private readonly InputAction m_Vehicles_Hover;
        private readonly InputAction m_Vehicles_Roll;
        private readonly InputAction m_Vehicles_LookSteer;
        private readonly InputAction m_Vehicles_Fire;
        private readonly InputAction m_Vehicles_CursorModeKeyboardOnly;
        public struct VehiclesActions
        {
            private @InputActions m_Wrapper;
            public VehiclesActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Thrust => m_Wrapper.m_Vehicles_Thrust;
            public InputAction @Hover => m_Wrapper.m_Vehicles_Hover;
            public InputAction @Roll => m_Wrapper.m_Vehicles_Roll;
            public InputAction @LookSteer => m_Wrapper.m_Vehicles_LookSteer;
            public InputAction @Fire => m_Wrapper.m_Vehicles_Fire;
            public InputAction @CursorModeKeyboardOnly => m_Wrapper.m_Vehicles_CursorModeKeyboardOnly;
            public InputActionMap Get() { return m_Wrapper.m_Vehicles; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(VehiclesActions set) { return set.Get(); }
            public void SetCallbacks(IVehiclesActions instance)
            {
                if (m_Wrapper.m_VehiclesActionsCallbackInterface != null)
                {
                    @Thrust.started -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnThrust;
                    @Thrust.performed -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnThrust;
                    @Thrust.canceled -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnThrust;
                    @Hover.started -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnHover;
                    @Hover.performed -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnHover;
                    @Hover.canceled -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnHover;
                    @Roll.started -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnRoll;
                    @Roll.performed -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnRoll;
                    @Roll.canceled -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnRoll;
                    @LookSteer.started -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnLookSteer;
                    @LookSteer.performed -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnLookSteer;
                    @LookSteer.canceled -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnLookSteer;
                    @Fire.started -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnFire;
                    @Fire.performed -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnFire;
                    @Fire.canceled -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnFire;
                    @CursorModeKeyboardOnly.started -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnCursorModeKeyboardOnly;
                    @CursorModeKeyboardOnly.performed -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnCursorModeKeyboardOnly;
                    @CursorModeKeyboardOnly.canceled -= m_Wrapper.m_VehiclesActionsCallbackInterface.OnCursorModeKeyboardOnly;
                }
                m_Wrapper.m_VehiclesActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Thrust.started += instance.OnThrust;
                    @Thrust.performed += instance.OnThrust;
                    @Thrust.canceled += instance.OnThrust;
                    @Hover.started += instance.OnHover;
                    @Hover.performed += instance.OnHover;
                    @Hover.canceled += instance.OnHover;
                    @Roll.started += instance.OnRoll;
                    @Roll.performed += instance.OnRoll;
                    @Roll.canceled += instance.OnRoll;
                    @LookSteer.started += instance.OnLookSteer;
                    @LookSteer.performed += instance.OnLookSteer;
                    @LookSteer.canceled += instance.OnLookSteer;
                    @Fire.started += instance.OnFire;
                    @Fire.performed += instance.OnFire;
                    @Fire.canceled += instance.OnFire;
                    @CursorModeKeyboardOnly.started += instance.OnCursorModeKeyboardOnly;
                    @CursorModeKeyboardOnly.performed += instance.OnCursorModeKeyboardOnly;
                    @CursorModeKeyboardOnly.canceled += instance.OnCursorModeKeyboardOnly;
                }
            }
        }
        public VehiclesActions @Vehicles => new VehiclesActions(this);

        // GUI
        private readonly InputActionMap m_GUI;
        private IGUIActions m_GUIActionsCallbackInterface;
        private readonly InputAction m_GUI_Pause;
        private readonly InputAction m_GUI_Select;
        private readonly InputAction m_GUI_Navigate;
        public struct GUIActions
        {
            private @InputActions m_Wrapper;
            public GUIActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Pause => m_Wrapper.m_GUI_Pause;
            public InputAction @Select => m_Wrapper.m_GUI_Select;
            public InputAction @Navigate => m_Wrapper.m_GUI_Navigate;
            public InputActionMap Get() { return m_Wrapper.m_GUI; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GUIActions set) { return set.Get(); }
            public void SetCallbacks(IGUIActions instance)
            {
                if (m_Wrapper.m_GUIActionsCallbackInterface != null)
                {
                    @Pause.started -= m_Wrapper.m_GUIActionsCallbackInterface.OnPause;
                    @Pause.performed -= m_Wrapper.m_GUIActionsCallbackInterface.OnPause;
                    @Pause.canceled -= m_Wrapper.m_GUIActionsCallbackInterface.OnPause;
                    @Select.started -= m_Wrapper.m_GUIActionsCallbackInterface.OnSelect;
                    @Select.performed -= m_Wrapper.m_GUIActionsCallbackInterface.OnSelect;
                    @Select.canceled -= m_Wrapper.m_GUIActionsCallbackInterface.OnSelect;
                    @Navigate.started -= m_Wrapper.m_GUIActionsCallbackInterface.OnNavigate;
                    @Navigate.performed -= m_Wrapper.m_GUIActionsCallbackInterface.OnNavigate;
                    @Navigate.canceled -= m_Wrapper.m_GUIActionsCallbackInterface.OnNavigate;
                }
                m_Wrapper.m_GUIActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Pause.started += instance.OnPause;
                    @Pause.performed += instance.OnPause;
                    @Pause.canceled += instance.OnPause;
                    @Select.started += instance.OnSelect;
                    @Select.performed += instance.OnSelect;
                    @Select.canceled += instance.OnSelect;
                    @Navigate.started += instance.OnNavigate;
                    @Navigate.performed += instance.OnNavigate;
                    @Navigate.canceled += instance.OnNavigate;
                }
            }
        }
        public GUIActions @GUI => new GUIActions(this);
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface IVehiclesActions
        {
            void OnThrust(InputAction.CallbackContext context);
            void OnHover(InputAction.CallbackContext context);
            void OnRoll(InputAction.CallbackContext context);
            void OnLookSteer(InputAction.CallbackContext context);
            void OnFire(InputAction.CallbackContext context);
            void OnCursorModeKeyboardOnly(InputAction.CallbackContext context);
        }
        public interface IGUIActions
        {
            void OnPause(InputAction.CallbackContext context);
            void OnSelect(InputAction.CallbackContext context);
            void OnNavigate(InputAction.CallbackContext context);
        }
    }
}
