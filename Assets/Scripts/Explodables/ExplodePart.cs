using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ToggleColliders))]
[RequireComponent(typeof(HoverPart))]
[RequireComponent(typeof(XRSimpleInteractable))]
[RequireComponent(typeof(AudioSource))]
public class ExplodePart : MonoBehaviour
{
    #region Variables
    [SerializeField, Tooltip("Local Positions")]
    Vector3 startPosition,
        endPosition;
    Vector3 currentPosition,
        destinationPosition;
    ToggleColliders colliderControl;

    float lerpSpeed = 1f;
    bool isExploded = false;

    #endregion


    private void Awake()
    {
        transform.localPosition = startPosition;
        colliderControl = GetComponent<ToggleColliders>();
    }

    public void AnimateExplosion()
    {
        StopAllCoroutines();
        currentPosition = transform.localPosition;
        destinationPosition = isExploded ? startPosition : endPosition;
        isExploded = !isExploded;
        if (isExploded)
        {
            StartCoroutine(LerpToPosition(currentPosition, destinationPosition));
        }
        else if (!isExploded)
        {
            StartCoroutine(ColliderToggle());
        }
    }

    IEnumerator LerpToPosition(Vector3 start, Vector3 end)
    {
        float timeElapsed = 0;

        while (timeElapsed < 1)
        {
            transform.localPosition = Vector3.Lerp(start, end, timeElapsed);
            timeElapsed += Time.deltaTime * lerpSpeed;
            yield return null;
        }
        transform.localPosition = end;
        if (isExploded)
        {
            yield return StartCoroutine(ColliderToggle());
        }
    }

    IEnumerator ColliderToggle()
    {
        colliderControl.ToggleChildColliders();
        yield return null;
        if (!isExploded)
        {
            yield return StartCoroutine(LerpToPosition(currentPosition, destinationPosition));
        }
    }
}
