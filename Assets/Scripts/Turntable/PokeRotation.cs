using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PokeRotation : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private XRHandSubsystem handSubsystem;
    private XRHandJoint fingerTip;

    [SerializeField]
    XRSimpleInteractable interactable;
    XRHand hand;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    bool canRotate = false;
    bool useLeftHand = false;

    private float yRotation;
    Rigidbody rb;
    #endregion

    #region Default Methods
    void Start()
    {
        handSubsystem = GetHandSubSystem();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!canRotate)
            return;

        StartRotation();
    }

    // Because I'm applying a physics force to the object, I'm calling it from fixed update
    void FixedUpdate()
    {
        if (!canRotate)
            return;
        RotateWithForce();
    }

    // Getting the interactable attached to this object and subscribing to the hover enter and exit events.
    void OnEnable()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        if (interactable != null)
        {
            interactable.hoverEntered.AddListener(OnFirstHoverEntered);
            interactable.hoverExited.AddListener(OnFirstHoverExited);
        }
    }

    void OnDisable()
    {
        if (interactable != null)
        {
            interactable.hoverEntered.RemoveListener(OnFirstHoverEntered);
            interactable.hoverExited.RemoveListener(OnFirstHoverExited);
        }
    }
    #endregion

    private void OnFirstHoverExited(HoverExitEventArgs arg0)
    {
        canRotate = false;
    }

    private void OnFirstHoverEntered(HoverEnterEventArgs args)
    {
        Debug.Log("HoverTriggered");
        if (args.interactorObject.handedness == InteractorHandedness.Left)
        {
            useLeftHand = true;
        }
        else if (args.interactorObject.handedness == InteractorHandedness.Right)
        {
            useLeftHand = false;
        }
        canRotate = true;
    }

    private XRHandSubsystem GetHandSubSystem()
    {
        List<XRHandSubsystem> subsystems = new List<XRHandSubsystem>();
        SubsystemManager.GetSubsystems(subsystems);

        if (subsystems.Count > 0)
        {
            Debug.Log("HandSubsystem found");
            return subsystems[0];
        }
        else
        {
            Debug.LogError("XRHandSubsystem not found.");
            return null;
        }
    }

    private void RotateWithForce()
    {
        rb.AddTorque(0, -yRotation, 0);
    }

    private void StartRotation()
    {
        XRHand hand = GetHand();
        fingerTip = hand.GetJoint(XRHandJointID.IndexTip);
        fingerTip.TryGetLinearVelocity(out Vector3 fingerVelocity);
        yRotation = fingerVelocity.x * rotateSpeed;
    }

    private XRHand GetHand()
    {
        if (handSubsystem != null)
        {
            XRHand leftHand = handSubsystem.leftHand;
            XRHand rightHand = handSubsystem.rightHand;
            hand = useLeftHand ? leftHand : rightHand;
        }
        return hand;
    }
}
