using UnityEngine;

namespace GG.Core
{
	/// <summary>
	/// Coordinates ordered loading of static classes
	/// </summary>
    internal static class StaticsInitializer
    {
	    #region RUNTIME INIT

	    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	    private static void OnSubsystemRegistration()
	    {
		    TickRouter.Init();
		    PoolManager.Init();
		    Modules.Init();
		    SceneController.Init();
		    PhysicsController.Init();
	    }

	    #endregion RUNTIME INIT
    }
}