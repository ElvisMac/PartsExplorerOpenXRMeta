using System;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{
    #region Variables
    List<ToggleColliders> colliders;
    Collider thisCollider;
    bool isNotExploded = true;
    bool canToggle = false;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisCollider = GetComponent<Collider>();
        InitialiseColliders();
    }

    private void OnEnable()
    {
        AllEventsMgr.OnToggle += ExplodeComponents;
        AllEventsMgr.OnAttached += EnableColliderFlip;
        AllEventsMgr.OnDetached += DisableColliderFlip;
    }

    private void OnDisable()
    {
        AllEventsMgr.OnToggle -= ExplodeComponents;
        AllEventsMgr.OnAttached -= EnableColliderFlip;
        AllEventsMgr.OnDetached -= DisableColliderFlip;
    }

    private void EnableColliderFlip()
    {
        canToggle = true;
    }

    private void DisableColliderFlip()
    { 
        canToggle = false; 
    }

    private void InitialiseColliders()
    {
        thisCollider.enabled = isNotExploded;
        //colliders = new();
        //foreach (Transform child in transform)
        //{
        //    ToggleColliders thisCollider = child.GetComponent<ToggleColliders>();
        //    colliders.Add(thisCollider);
        //    thisCollider.FlipColliders();
        //}
    }

    public void ExplodeComponents()
    {
        if (canToggle)
        {
            isNotExploded = !isNotExploded;
            thisCollider.enabled = isNotExploded;
        }
    }
}
