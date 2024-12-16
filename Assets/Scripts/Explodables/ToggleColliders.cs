using System.Collections.Generic;
using UnityEngine;

public class ToggleColliders : MonoBehaviour
{
    bool isExploded = false;
    bool canToggleColliders = false;
    Collider childCollider;

    List<Transform> childTransforms;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetChildrenTransforms();
        FlipColliders();
    }

    private void OnEnable()
    {
        AllEventsMgr.OnToggle += ToggleExplode;
        AllEventsMgr.OnAttached += SetColliderToggleTrue;
        AllEventsMgr.OnDetached += SetColliderToggleFalse;
    }

    private void OnDisable()
    {
        AllEventsMgr.OnToggle -= ToggleExplode;
        AllEventsMgr.OnAttached -= SetColliderToggleTrue;
        AllEventsMgr.OnDetached -= SetColliderToggleFalse;
    }

    private void GetChildrenTransforms()
    {
        if (childTransforms == null)
        {
            childTransforms = new();
            foreach (Transform child in transform)
            {
                childTransforms.Add(child);
            }
        }
    }

    public void FlipColliders()
    {
        foreach (Transform child in childTransforms)
        {
            childCollider = child.GetComponent<Collider>();
            childCollider.enabled = isExploded;
        }
    }

    public void ToggleExplode()
    {
        if (canToggleColliders)
        {
            isExploded = !isExploded;
            FlipColliders();
        }
    }

    private void SetColliderToggleTrue()
    {
        canToggleColliders = true;
    }
    private void SetColliderToggleFalse()
    {
        canToggleColliders = false;
    }
}
