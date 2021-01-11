using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GGUnityInput
{
    /// <summary>
    /// Collects and routes player input for characters.
    /// </summary>
    public class PlayerCharacterInputRouter : MonoBehaviour, PlayerInputMap.ICharacterActions
    {
        #region Singleton

        public static PlayerCharacterInputRouter Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                Setup();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion Singleton


        #region Variables

        // Private
        private readonly List<IPlayerCharacterInputListener> _components = new List<IPlayerCharacterInputListener>();
        private PlayerInputMap _inputMap;

        #endregion Variables


        #region Initialization

        /// <summary>
        /// Initializes the system, hooks up to input map.
        /// </summary>
        private void Setup()
        {
            if (_inputMap == null)
            {
                _inputMap = new PlayerInputMap();
                _inputMap.Character.SetCallbacks(this);
            }
            _inputMap.Character.Enable();
        }

        #endregion Initialization


        #region Registration

        public void RegisterListener(IPlayerCharacterInputListener component)
        {
            _components.Add(component);
        }
        
        public void UnregisterListener(IPlayerCharacterInputListener component)
        {
            _components.Remove(component);
        }

        #endregion Registration
        
        
        #region Input

        void PlayerInputMap.ICharacterActions.OnMove(InputAction.CallbackContext context)
        {
            Vector2 value = context.ReadValue<Vector2>();
            foreach (IPlayerCharacterInputListener component in _components)
            {
                component.MoveInput = value;
            }
        }

        void PlayerInputMap.ICharacterActions.OnLook(InputAction.CallbackContext context)
        {
            Vector2 value = context.ReadValue<Vector2>();
            foreach (IPlayerCharacterInputListener component in _components)
            {
                component.LookInput = value;
            }
        }

        void PlayerInputMap.ICharacterActions.OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                foreach (IPlayerCharacterInputListener component in _components)
                {
                    component.OnJump();
                }
            }
        }

        void PlayerInputMap.ICharacterActions.OnCrouchToggle(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                foreach (IPlayerCharacterInputListener component in _components)
                {
                    component.OnCrouchToggle();
                }
            }
        }

        void PlayerInputMap.ICharacterActions.OnSprintToggle(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                foreach (IPlayerCharacterInputListener component in _components)
                {
                    component.OnSprintToggle();
                }
            }
        }

        #endregion Input
    }
}
