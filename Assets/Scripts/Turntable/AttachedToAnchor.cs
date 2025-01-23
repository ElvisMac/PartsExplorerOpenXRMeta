using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class AttachedToAnchor : MonoBehaviour
{
    XRSocketInteractor interactor;
    ModelController controllerControl;

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
        controllerControl = args.interactableObject.transform.GetComponent<ModelController>();
        controllerControl.CanToggle = true;
        //controllerControl.ModelHeld(true);
        AllEventsMgr.AttachToAnchor();
    }

    private void SendDetachedMessage(SelectExitEventArgs args)
    {
        controllerControl.CanToggle = false;
        //controllerControl.ModelHeld(false);
        controllerControl = null;
        AllEventsMgr.DetachFromAnchor();
    }
}
