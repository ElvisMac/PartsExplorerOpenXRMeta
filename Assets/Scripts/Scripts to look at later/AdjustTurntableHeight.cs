using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustTurntableHeight : MonoBehaviour
{
    [SerializeField, Tooltip("Local positions")]
    private Vector3 _startPosition, _endPosition;

    private float _currentPercent = 0f, _desiredPercent = 0f;

    private void Awake() {
        transform.localPosition = _startPosition;
    }

    /// <summary>
    /// Set percent of the explosion. This sets the local position to a position between the _startPosition and _endPosition by percent.
    /// </summary>
    /// <param name="percent">desired percent</param>
    /// <param name="instant">If true, the position is instantly updated without a lerp. False by default</param>
    public void SetPercent(float percent) {
        _desiredPercent = percent;
        _currentPercent = _desiredPercent;
        UpdateLerpPosition();
    }

    private void UpdateLerpPosition() {
        transform.localPosition = Vector3.Lerp(_startPosition, _endPosition, _currentPercent);
    }
}