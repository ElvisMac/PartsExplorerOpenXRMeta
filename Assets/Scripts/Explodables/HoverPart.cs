using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(XRSimpleInteractable))]

public class HoverPart : MonoBehaviour
{
    [SerializeField] private XRSimpleInteractable interactable;
    [SerializeField] private Material glowMaterial;
    private AudioSource hoverSound;
    private Renderer childRend;
    private Material[] defaultMaterial;
    private Material[] glowMatGroup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Material setup for swapping on hover
        defaultMaterial = GetComponentInChildren<Renderer>().materials;
        glowMatGroup = new Material[defaultMaterial.Length + 1];
        for (int i = 0; i < glowMatGroup.Length; i++)
        {
            glowMatGroup[i] = glowMaterial;
        }
        hoverSound = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        // Caching the attached XRSimpleInteractable
        interactable = GetComponent<XRSimpleInteractable>();
        if (interactable != null)
        {
            interactable.hoverEntered.AddListener(OnHoverStart);
            interactable.hoverExited.AddListener(OnHoverEnd);
        }
    }

    private void OnHoverStart(HoverEnterEventArgs args)
    {
        SwapMaterials(glowMatGroup);
        hoverSound.Play();
    }

    private void OnHoverEnd(HoverExitEventArgs args)
    {
        SwapMaterials(defaultMaterial);
    }

    private void SwapMaterials(Material[] newMaterial)
    {
        foreach (Transform child in transform)
        {
            childRend = child.GetComponent<Renderer>();
            childRend.materials = newMaterial;
        }
    }
}
