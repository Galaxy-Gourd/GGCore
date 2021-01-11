using UnityEngine;

namespace GGUnityInput
{
    public interface IPlayerCharacterInputListener
    {
        Vector2 MoveInput { set; }
        Vector2 LookInput { set; }
        
        void OnJump();
        void OnCrouchToggle();
        void OnSprintToggle();
    }
}