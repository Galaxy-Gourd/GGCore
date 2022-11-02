namespace GG.Core
{
    public enum TickGroup
    {
        // GG generic
        Physics,                // Ticks physics simulation
        Input,                  // Ticks raw input device listening
        InputTransmission,      // Ticks sending input values to listeners
        UIUpdate,
        Debug,                  // Ticks debug visualizations
        
        // KCC2D
        ControllerKCC2D,
        ViewKCC2D,
        
        // App-Specific
        ControllerShip,
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