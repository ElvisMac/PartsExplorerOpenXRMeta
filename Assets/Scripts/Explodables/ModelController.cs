using System;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{
    #region Variables
    List<ToggleColliders> colliders;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitialiseColliders();
    }

    // Update is called once per frame

    private void InitialiseColliders()
    {
        colliders = new();
        foreach (Transform child in transform)
        {
            ToggleColliders thisCollider = child.GetComponent<ToggleColliders>();
            colliders.Add(thisCollider);
            thisCollider.FlipColliders();
        }
    }

    public void ExplodeComponents()
    {
        AllEventsMgr.ToggleExplode();
    }
}
