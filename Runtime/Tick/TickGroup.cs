namespace GG.Core
{
    public enum TickGroup
    {
        // GG generic
        Physics,                // Ticks physics simulation
        Input,                  // Ticks raw input device listening
        InputTransmission,      // Ticks sending input values to receivers
        UIUpdate,
        Debug,                  // Ticks debug visualizations
        
        // KCC2D
        ControllerKCC2D,        // Ticks physics calcs for KCC2D
        ViewKCC2D,              // Ticks interpolation for KCC2D view
        
        // App-Specific
        ControllerShip,
        ControllerHumanoid,
        CameraMovement,
        PhysicsRaycast,
        VisionCaster,
        VisibleObjectBoundsRefresh,
        InteractionSystem,
        
        // Defaults
        DefaultGroupUpdate,
        DefaultGroupFixedUpdate,
        DefaultGroupLateUpdate,
        DefaultGroupTenthSecond,
        DefaultGroupHalfSecond,
        DefaultGroupFullSecond,
        DefaultGroupTwoSeconds,
        DefaultGroupFiveSeconds
    }
}