using System.Collections.Generic;
using UnityEngine;

public class ComponentMaster : MonoBehaviour
{
    MoveComponent moveComponent;
    BoxCollider boxCollider;
    Vector3 colliderScaleDefault;
    bool isExploded;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        colliderScaleDefault = boxCollider.size;
        isExploded = false;
    }

    public void ExplodeComponent()
    {
        List<Transform> children = GetChildren(transform);

        isExploded = !isExploded;

        boxCollider.size = isExploded ? Vector3.zero : colliderScaleDefault;

        foreach (Transform child in children)
        {
            moveComponent = GameObject.Find(child.name).GetComponent<MoveComponent>();
            moveComponent.DisableEnableChildren(isExploded);
        }
    }

    /* Returns a list of children objects to be used in Explode component to disable or
     * enable the colliders depending on the exploded state. */
    private List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new();

        foreach (Transform child in parent)
        {
            children.Add(child);
        }

        return children;
    }
}
