using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class DisableFarInteraction : MonoBehaviour
{
    private NearFarInteractor interactor;

    private void Start()
    {
        interactor = GetComponent<NearFarInteractor>();
    }
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
    }

    private void EnableFarInteractor()
    {
        interactor.enableFarCasting = true;
    }
}
