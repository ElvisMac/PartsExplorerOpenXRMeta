using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

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
