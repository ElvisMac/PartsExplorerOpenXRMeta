using System.Collections;
using UnityEngine;

public class ExplodePart : MonoBehaviour
{
    #region Variables
    [SerializeField, Tooltip("Local Positions")]
    Vector3 startPosition,
        endPosition;
    Vector3 currentPosition,
        destinationPosition;

    float lerpSpeed = 1f;
    bool isExploded = false;

    #endregion


    private void Awake()
    {
        transform.localPosition = startPosition;
    }

    public void AnimateExplosion()
    {
        StopAllCoroutines();
        currentPosition = transform.localPosition;
        destinationPosition = isExploded ? startPosition : endPosition;
        isExploded = !isExploded;
        StartCoroutine(LerpToPosition(currentPosition, destinationPosition));
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
    }
}
