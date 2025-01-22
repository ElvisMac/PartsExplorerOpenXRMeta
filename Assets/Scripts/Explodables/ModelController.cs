using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class ModelController : MonoBehaviour
{
    #region Variables
    XRGrabInteractable thisInteractable;

    //ToggleColliders[] colliderControl;
    ExplodePart[] explodeParts;
    Collider thisCollider;
    bool isNotExploded = true;
    bool canToggle = false;

    [SerializeField]
    Vector3 modelDefaultScale;
    #endregion

    #region Properties
    public bool CanToggle
    {
        get { return canToggle; }
        set { canToggle = value; }
    }
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisCollider = GetComponent<Collider>();
        thisInteractable = GetComponent<XRGrabInteractable>();
        InitialiseChildScripts();
        modelDefaultScale = transform.localScale;
    }

    private void OnEnable()
    {
        AllEventsMgr.OnToggleExplode += ExplodeComponents;
    }

    private void OnDisable()
    {
        AllEventsMgr.OnToggleExplode -= ExplodeComponents;
    }

    /*
     * Sets the default colliders list with all the child toggle colliders and explodepart scripts
     */
    private void InitialiseChildScripts()
    {
        thisCollider.enabled = isNotExploded;
        //colliderControl = transform.GetComponentsInChildren<ToggleColliders>();
        explodeParts = transform.GetComponentsInChildren<ExplodePart>();
    }

    //private void FlipChildrenColliders()
    //{
    //    foreach (ToggleColliders child in colliderControl)
    //    {
    //        child.ToggleChildColliders();
    //    }
    //}

    private void ExplodeChildrenObjects()
    {
        foreach (ExplodePart part in explodeParts)
        {
            part.AnimateExplosion();
        }
    }

    public void ExplodeComponents()
    {
        if (canToggle)
        {
            Debug.Log("Trying to Explode the connected part");
            isNotExploded = !isNotExploded;
            thisCollider.enabled = isNotExploded;
            ExplodeChildrenObjects();
            //FlipChildrenColliders();
        }
    }

    public void ResetScale()
    {
        transform.localScale = modelDefaultScale;
    }
}
