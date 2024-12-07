using System.Collections.Generic;
using UnityEngine;

public class ToggleColliders : MonoBehaviour
{
    bool isExploded = false;
    Collider childCollider;

    List<Transform> childTransforms;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetChildrenTransforms();
        FlipColliders();
    }

    // Update is called once per frame
    void Update() { }

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
        isExploded = !isExploded;
        FlipColliders();
    }
}
