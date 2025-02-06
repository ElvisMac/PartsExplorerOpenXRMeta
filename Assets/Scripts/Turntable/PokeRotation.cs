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
    private Vector3 _startPosition, _endPosition;

    private float _currentPercent = 0f, _desiredPercent = 0f;

    [SerializeField]
    bool canRotate = false;
    bool useLeftHand = false;

    private float yRotation;
    Rigidbody rb;
    #endregion

    #region TurntableVariables
    [Header("Turntable Shape")]
    [SerializeField]
    [Tooltip("The local height of the upper section of the turntable.")]
    private float _tableHeight;
    public float TableHeight => _tableHeight;

    [SerializeField]
    [Tooltip("The radius of the upper section of the turntable.")]
    private float _tableRadius;
    public float TableRadius => _tableRadius;

    [SerializeField]
    [Tooltip("The length of the edge that connects the upper and lower sections of the turntable.")]
    private float _edgeLength;

    [Range(0, 90)]
    [SerializeField]
    [Tooltip("The angle the edge forms with the upper section of the turntable.")]
    private float _edgeAngle = 45;

    public float LowerLevelHeight
    {
        get { return _tableHeight - _edgeLength * Mathf.Sin(_edgeAngle * Mathf.Deg2Rad); }
    }

    public float LowerLevelRadius
    {
        get { return _tableRadius + _edgeLength * Mathf.Cos(_edgeAngle * Mathf.Deg2Rad); }
    }
    #endregion

    #region Default Methods
    void Start()
    {
        handSubsystem = GetHandSubSystem();
        rb = GetComponent<Rigidbody>();
        SetHeight(0.5f);
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

    public void SetHeight(float percent)
    {
        _desiredPercent = percent;
        _currentPercent = _desiredPercent;
        UpdateLerpPosition();
    }

    private void UpdateLerpPosition()
    {
        transform.position = Vector3.Lerp(_startPosition, _endPosition, _currentPercent);
    }
}
