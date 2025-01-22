using System;

public static class AllEventsMgr
{
    #region Public Events
    public static event Action OnToggleExplode;
    public static event Action OnAttachToAnchor;
    public static event Action OnDetachFromAnchor;
    public static event Action<string, string> OnPartHover;
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

    public static void PartHover(string name, string value)
    {
        OnPartHover?.Invoke(name, value);
    }
    #endregion
}
