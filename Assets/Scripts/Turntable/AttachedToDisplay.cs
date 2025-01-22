using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class AttachedToDisplay : MonoBehaviour
{
    XRSocketInteractor interactor;
    ModelController attachedObject;

    private void Awake()
    {
        interactor = GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        interactor.hoverEntered.AddListener(IsHovering);
        interactor.selectExited.AddListener(IsDetatched);
    }

    private void OnDisable()
    {
        interactor.hoverEntered.RemoveListener(IsHovering);
        interactor.selectExited.RemoveListener(IsDetatched);
    }

    private void IsHovering(HoverEnterEventArgs args)
    {
        attachedObject = args.interactorObject.transform.GetComponent<ModelController>();
    }

    private void IsDetatched(SelectExitEventArgs args)
    {
        attachedObject.ResetScale();
    }
}
