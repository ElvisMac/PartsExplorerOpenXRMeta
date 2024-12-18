using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ModelController : MonoBehaviour
{
    #region Variables
    List<ToggleColliders> colliderControl;
    List<ExplodePart> explodeParts;
    Collider thisCollider;
    bool isNotExploded = true;
    bool canToggle = false;
    #endregion

    #region Properties
    public bool CanToggle
    {
        get { return canToggle; }
        set 
        { 
            canToggle = value;
        }
    }
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisCollider = GetComponent<Collider>();
        InitialiseChildScripts();
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
        colliderControl = new();
        explodeParts = new();
        foreach (Transform child in transform)
        {
            ExplodePart childExplodePart = child.GetComponent<ExplodePart>();
            ToggleColliders childCollider = child.GetComponent<ToggleColliders>();

            colliderControl.Add(childCollider);
            explodeParts.Add(childExplodePart);
        }
    }

    private void FlipChildrenColliders() 
    {
        foreach (ToggleColliders child in transform)
        {
            child.ToggleChildColliders();
        }
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
            Debug.Log("Trying to Explode the connected part");
            isNotExploded = !isNotExploded;
            thisCollider.enabled = isNotExploded;
            ExplodeChildrenObjects();
            FlipChildrenColliders();
        }
    }
}
