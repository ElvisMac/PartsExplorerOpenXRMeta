using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class ModelController : MonoBehaviour
{
    #region Variables
    XRGrabInteractable interactable;
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
        interactable = GetComponent<XRGrabInteractable>();
        //interactable.selectEntered.AddListener(ModelHeld);
        //interactable.selectExited.AddListener(ModelReleased);
        AllEventsMgr.OnToggleExplode += ExplodeComponents;
    }

    private void OnDisable()
    {
        //interactable.selectEntered.RemoveListener(ModelHeld);
        //interactable.selectExited.RemoveListener(ModelReleased);
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
            //FlipChildrenColliders();
        }
    }

    //public void ModelHeld(SelectEnterEventArgs args)
    //{
    //    //isHeld = true;
    //    transform.localScale.Set(modelDefaultScale.x, modelDefaultScale.y, modelDefaultScale.z);
    //}

    //public void ModelReleased(SelectExitEventArgs args)
    //{
    //    //isHeld = false;
    //}

}
