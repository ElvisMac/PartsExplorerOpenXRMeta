using System;
using UnityEngine;

public static class AllEventsMgr
{
    #region Public Events
    public static event Action OnToggle;

    #endregion

    #region Public Invokers
    public static void ToggleExplode()
    {
        Debug.Log("Invoking Explode Event");
        OnToggle.Invoke();
    }

    #endregion
}
