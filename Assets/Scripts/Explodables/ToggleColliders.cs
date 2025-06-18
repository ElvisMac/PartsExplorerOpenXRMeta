using System.Collections.Generic;
using UnityEngine;

/*
 * Collider toggling is handled here for the parts of the object they come under.
 * Rather than reference each collider explicity, this loops through the child
 * objects and toggles the colliders on or off.
 */
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
