using System.Collections.Generic;
using UnityEngine;

public class ToggleColliders : MonoBehaviour
{
    bool isExploded = false;

    List<Collider> childTransforms;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GetChildrenTransforms();
        FlipColliders();
    }

    private void GetChildrenTransforms()
    {
        if (childTransforms == null)
        {
            childTransforms = new();
            foreach (Transform child in transform)
            {
                childTransforms.Add(child.GetComponent<Collider>());
            }
        }
    }

    public void FlipColliders()
    {
        foreach (Collider child in childTransforms)
        {
            child.enabled = isExploded;
        }
    }

    public void ToggleChildColliders()
    {
        isExploded = !isExploded;
        FlipColliders();
    }
}
