using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    // The part of the brake unit that the script will animate
    [SerializeField]
    private AssemblySO assembly;
    private Material[] defaultMaterial;

    [SerializeField]
    private Material hoverMaterial;

    private Collider componentMesh;

    public void Awake()
    {
        DisableEnableChildren(false);
        defaultMaterial = gameObject.GetComponentInChildren<Renderer>().materials;
    }

    public void HoverStart()
    {
        UpdateTextFields utf = FindFirstObjectByType<UpdateTextFields>();
        utf.UpdateTextElements(assembly.itemName, assembly.itemDescription);

        HoverMaterial();
    }

    public void HoverEnd()
    {
        List<Transform> children = GetChildren(transform);
        Renderer rend;

        foreach (Transform child in children)
        {
            rend = GameObject.Find(child.name).GetComponent<Renderer>();
            rend.materials = defaultMaterial;
        }
    }

    private void HoverMaterial()
    {
        List<Transform> children = GetChildren(transform);
        Renderer rend;

        foreach (Transform child in children)
        {
            rend = GameObject.Find(child.name).GetComponent<Renderer>();
            Material[] tempMats = rend.materials;

            for (int i = 0; i < tempMats.Length; i++)
            {
                tempMats[i] = hoverMaterial;
            }

            rend.materials = tempMats;
        }
    }

    public void DisableEnableChildren(bool enabled)
    {
        List<Transform> children = GetChildren(transform);

        foreach (Transform child in children)
        {
            componentMesh = GameObject.Find(child.name).GetComponent<Collider>();
            componentMesh.enabled = enabled;
            // Debug.Log(componentMesh.name + ": " + componentMesh.enabled);
        }
    }

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
