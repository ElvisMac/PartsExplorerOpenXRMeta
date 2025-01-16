using System;
using UnityEngine;

public static class AllEventsMgr
{
    #region Public Events
    public static event Action OnToggleExplode;
    #endregion

    #region Public Invokers
    public static void ToggleExplode()
    {
        OnToggleExplode?.Invoke();
    }
    #endregion
}
