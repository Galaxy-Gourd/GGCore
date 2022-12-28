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
        
        // App-Specific
        ControllerHumanoid,
        CameraMovement,
        PhysicsRaycast,
        VisionCaster,
        VisibleObjectBoundsRefresh,
        InteractionSystem,
        PhysicsDiscoverableSleepTick,
        
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