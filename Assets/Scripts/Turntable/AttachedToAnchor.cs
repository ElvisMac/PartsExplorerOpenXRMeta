using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class AttachedToAnchor : MonoBehaviour
{
    XRSocketInteractor interactor;

    private void Awake()
    {
        interactor = GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        interactor.selectEntered.AddListener(SendAttachedMessage);
        interactor.selectExited.AddListener(SendDetachedMessage);
    }

    private void OnDisable()
    {
        interactor.selectEntered.RemoveListener(SendAttachedMessage);
        interactor.selectExited.RemoveListener(SendDetachedMessage);
    }

    private void SendAttachedMessage(SelectEnterEventArgs args)
    {
        AllEventsMgr.ItemAttached();
    }

    private void SendDetachedMessage(SelectExitEventArgs args)
    {
        AllEventsMgr.ItemDetached();
    }
}
