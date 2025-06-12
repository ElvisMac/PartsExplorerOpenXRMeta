using System;

/*
 * This allows any of the scripts to invoke or subscribe to events listed within
 * so that they can either trigger, or respond to, any events within.  There is no
 * need to reference this when triggering as you can just invoke the methods using
 * the class name followed by the method name.  If you want to listen for these
 * events being triggered, then there is a bit more that needs adding to the receiving
 * scripts that you will see as you read further scripts within this project.
 */
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
