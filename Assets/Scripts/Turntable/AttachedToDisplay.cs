using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

/*
 * NOT CURRENTLY USED DUE TO SCALING ISSUES
 * This allows an object to attach to a plynth provided it is the correct item
 * that should be attaching to it.  This is controlled in the inspector in Unity
 * when you add a new model that requires a shelf to hold it.
 */
public class AttachedToDisplay : MonoBehaviour
{
    XRSocketInteractor interactor;
    Transform attachedObject;
    Vector3 attachedScale = new Vector3(0.5f,0.5f,0.5f);
    Vector3 originalScale;

    private void Awake()
    {
        interactor = GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        interactor.selectEntered.AddListener(IsAttached);
        interactor.selectExited.AddListener(IsDetatched);
    }

    private void OnDisable()
    {
        interactor.selectEntered.RemoveListener(IsAttached);
        interactor.selectExited.RemoveListener(IsDetatched);
    }

    private void IsAttached(SelectEnterEventArgs args)
    {
        attachedObject = args.interactableObject.transform;
        originalScale = attachedObject.localScale;
        //attachedObject.localScale = attachedScale;
    }

    private void IsDetatched(SelectExitEventArgs args)
    {
        attachedObject.localScale = originalScale;
    }
}
