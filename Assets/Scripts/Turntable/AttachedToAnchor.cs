using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

/*
 * Deals with triggering events that pertain to attaching and detaching from the
 * turntable anchor.
 */
public class AttachedToAnchor : MonoBehaviour
{
    [SerializeField]
    ShelfController shelves;
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
        
        /* I disabled this because it causes unwanted problems when someone accidentally
         * dropped the object back on to the turntable when they actually wanted to place
         * back on its assigned pedestal.
         */
        //shelves.TriggerShelves();
        
    }

    private void SendDetachedMessage(SelectExitEventArgs args)
    {
        controllerControl.CanToggle = false;
        //controllerControl.ModelHeld(false);
        controllerControl = null;
        AllEventsMgr.DetachFromAnchor();
    }
}
