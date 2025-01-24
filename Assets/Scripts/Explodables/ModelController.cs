using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
[RequireComponent(typeof(Rigidbody))]
public class ModelController : MonoBehaviour
{
    #region Variables
    ExplodePart[] explodeParts;
    Collider thisCollider;
    bool isNotExploded = true;
    bool canToggle = false;
    bool isHeld = false;

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
        InitialiseChildScripts();
    }

    private void Update()
    {
        if (isHeld)
        {
            transform.localScale = modelDefaultScale;
        }
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
        explodeParts = transform.GetComponentsInChildren<ExplodePart>();
    }

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
            isNotExploded = !isNotExploded;
            thisCollider.enabled = isNotExploded;
            ExplodeChildrenObjects();
        }
    }
}
