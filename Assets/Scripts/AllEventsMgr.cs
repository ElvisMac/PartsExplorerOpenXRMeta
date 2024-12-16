using System;
using UnityEngine;

public static class AllEventsMgr
{
    #region Public Events
    public static event Action OnToggle;
    public static event Action OnAttached;
    public static event Action OnDetached;

    #endregion

    #region Public Invokers
    public static void ToggleExplode()
    {
        Debug.Log("Invoking Explode Event");
        OnToggle.Invoke();
    }

    public static void ItemAttached()
    {
        OnAttached.Invoke();
    }

    public static void ItemDetached()
    {
        OnDetached.Invoke();
    }
    #endregion
}
