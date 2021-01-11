// GENERATED AUTOMATICALLY FROM 'Packages/com.galaxygourd.grpginput/Runtime/Data/PlayerInputMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace GRPG.Input
{
    public class @PlayerInputMap : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputMap()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputMap"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""265c38f5-dd18-4d34-b198-aec58e1627ff"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""50fd2809-3aa3-4a90-988e-1facf6773553"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""look"",
                    ""type"": ""Value"",
                    ""id"": ""c60e0974-d140-4597-a40e-9862193067e9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""84261370-43b7-4bdd-b2a5-ac8ad5ab4a88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""crouchToggle"",
                    ""type"": ""Button"",
                    ""id"": ""c57b1f50-2a20-478f-a38f-b9ae109ba713"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""sprintToggle"",
                    ""type"": ""Button"",
                    ""id"": ""2f2babad-f742-4b24-a7f8-8111497a7522"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e1b8c4dd-7b3a-4db6-a93a-0889b59b1afc"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Dpad"",
                    ""id"": ""cefc16fc-557a-44b0-939f-2ad792876b07"",
                    ""path"": ""Dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""07244659-79df-461d-b329-defbe2fbc5f6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f0ec75cb-f02c-40d2-a33f-1fd6eab2ae0b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""21fe6bfe-4721-4483-9f4a-a0031ade105c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2dd39746-c75c-4a11-838a-e59eacaf4e0b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c106d6e6-2780-47ff-b318-396171bd54cc"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""578caa03-6827-4797-adfc-a59770c437fe"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=2,y=2)"",
                    ""groups"": """",
                    ""action"": ""look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb1f981c-abe5-429f-bacb-6be17eae7ce6"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63d18b86-e018-4ca8-95c8-4ba332b2cb9c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11a3bfac-24b6-42bc-bd99-f8dda219e26e"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""crouchToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1707e8dd-2379-4dc9-a936-41930f958dfa"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""crouchToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e820b1b2-8995-41d3-a64c-d2fccd9caf55"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""sprintToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc9b9cb1-e9c7-4c13-9916-92716b35dcb6"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""sprintToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Character
            m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
            m_Character_move = m_Character.FindAction("move", throwIfNotFound: true);
            m_Character_look = m_Character.FindAction("look", throwIfNotFound: true);
            m_Character_jump = m_Character.FindAction("jump", throwIfNotFound: true);
            m_Character_crouchToggle = m_Character.FindAction("crouchToggle", throwIfNotFound: true);
            m_Character_sprintToggle = m_Character.FindAction("sprintToggle", throwIfNotFound: true);
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

        // Character
        private readonly InputActionMap m_Character;
        private ICharacterActions m_CharacterActionsCallbackInterface;
        private readonly InputAction m_Character_move;
        private readonly InputAction m_Character_look;
        private readonly InputAction m_Character_jump;
        private readonly InputAction m_Character_crouchToggle;
        private readonly InputAction m_Character_sprintToggle;
        public struct CharacterActions
        {
            private @PlayerInputMap m_Wrapper;
            public CharacterActions(@PlayerInputMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @move => m_Wrapper.m_Character_move;
            public InputAction @look => m_Wrapper.m_Character_look;
            public InputAction @jump => m_Wrapper.m_Character_jump;
            public InputAction @crouchToggle => m_Wrapper.m_Character_crouchToggle;
            public InputAction @sprintToggle => m_Wrapper.m_Character_sprintToggle;
            public InputActionMap Get() { return m_Wrapper.m_Character; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
            public void SetCallbacks(ICharacterActions instance)
            {
                if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
                {
                    @move.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                    @move.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                    @move.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                    @look.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLook;
                    @look.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLook;
                    @look.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLook;
                    @jump.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                    @jump.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                    @jump.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                    @crouchToggle.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnCrouchToggle;
                    @crouchToggle.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnCrouchToggle;
                    @crouchToggle.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnCrouchToggle;
                    @sprintToggle.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnSprintToggle;
                    @sprintToggle.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnSprintToggle;
                    @sprintToggle.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnSprintToggle;
                }
                m_Wrapper.m_CharacterActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @move.started += instance.OnMove;
                    @move.performed += instance.OnMove;
                    @move.canceled += instance.OnMove;
                    @look.started += instance.OnLook;
                    @look.performed += instance.OnLook;
                    @look.canceled += instance.OnLook;
                    @jump.started += instance.OnJump;
                    @jump.performed += instance.OnJump;
                    @jump.canceled += instance.OnJump;
                    @crouchToggle.started += instance.OnCrouchToggle;
                    @crouchToggle.performed += instance.OnCrouchToggle;
                    @crouchToggle.canceled += instance.OnCrouchToggle;
                    @sprintToggle.started += instance.OnSprintToggle;
                    @sprintToggle.performed += instance.OnSprintToggle;
                    @sprintToggle.canceled += instance.OnSprintToggle;
                }
            }
        }
        public CharacterActions @Character => new CharacterActions(this);
        public interface ICharacterActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnCrouchToggle(InputAction.CallbackContext context);
            void OnSprintToggle(InputAction.CallbackContext context);
        }
    }
}
