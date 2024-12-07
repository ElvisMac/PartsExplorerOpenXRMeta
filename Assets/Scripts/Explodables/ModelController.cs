using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{
    List<ToggleColliders> colliders;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitialiseColliders();
    }

    // Update is called once per frame
    void Update() { }

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
}
