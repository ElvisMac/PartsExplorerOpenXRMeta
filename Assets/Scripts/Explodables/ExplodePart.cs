using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

// Adds all of the required components to ensure this script can operate.
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ToggleColliders))]
[RequireComponent(typeof(HoverPart))]
[RequireComponent(typeof(XRSimpleInteractable))]
[RequireComponent(typeof(AudioSource))]

/*
 * This class is responsible for lerping the component it is attached to 
 * from its default position, to its exploded position and back again.
 * This uses coroutines to do this to prevent unwanted behaviours in the
 * gameobjects being moved.
 */
public class ExplodePart : MonoBehaviour
{
    #region Variables
    /*
     * These positions will need to be manually set in the inspector for 
     * the desired start and end positions.
     */
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

    /*
     * This carries out the movement of the part its assigned to. It also deals with 
     * enabling or disabling the colliders based on the explosion state. Colliders 
     * need to be disabled when the model is assembled otherwise it causes stuttering
     * and lag in the headset, causing feeling of nausea and potential headaches.
     */
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
