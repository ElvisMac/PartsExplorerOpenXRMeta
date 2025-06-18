using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

/*
 * This is effectively a brute force disabling of the FarInteraction due
 * to it turning itself back on when it wasn't required.  This ensures that
 * when a model is on the turntable that the far interaction doesn't interfere
 * with rotating the model which proved to be infuriating when trying to 
 * hover over parts in the exploded state.
 */
public class DisableFarInteraction : MonoBehaviour
{
    private NearFarInteractor interactor;
    private bool farDisabled = false;

    private void Start()
    {
        interactor = GetComponent<NearFarInteractor>();
    }

    private void Update()
    {
        if (farDisabled && interactor.enableFarCasting == true)
        {
            interactor.enableFarCasting = false;
        }
    }

    /*
     * This is how I subscribe to events in the AllEventsManager. When something 
     * triggers the methods that are subscribed, it will call the methods in this
     * class that are required to execute on that activation.
     */
    private void OnEnable()
    {
        AllEventsMgr.OnAttachToAnchor += DisableFarInteractor;
        AllEventsMgr.OnDetachFromAnchor += EnableFarInteractor;
    }

    private void OnDisable()
    {
        AllEventsMgr.OnAttachToAnchor -= DisableFarInteractor;
        AllEventsMgr.OnDetachFromAnchor -= EnableFarInteractor;
    }

    private void DisableFarInteractor()
    {
        interactor.enableFarCasting = false;
        farDisabled = true;
    }

    private void EnableFarInteractor()
    {
        interactor.enableFarCasting = true;
        farDisabled = false;
    }
}
