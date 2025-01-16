using System;
using UnityEngine;

public static class AllEventsMgr
{
    #region Public Events
    public static event Action OnToggleExplode;
    public static event Action OnAttachToAnchor;
    public static event Action OnDetachFromAnchor;
    #endregion

    #region Public Invokers
    public static void ToggleExplode()
    {
        OnToggleExplode?.Invoke();
    }

    public static void AttachToAnchor()
    {
        OnAttachToAnchor?.Invoke();
    }

    public static void DetachFromAnchor()
    {
        OnDetachFromAnchor?.Invoke();
    }
    #endregion
}
