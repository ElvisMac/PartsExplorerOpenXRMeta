using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

/*  The Execute always flag must be enabled to make sure the notches get generated.
 *  Just uncomment it then refresh the Unity editor. Once the notches have been
 *  generated, come back to this script and comment the ExecuteAlways below, save
 *  then refresh the editor again.  At this point you should be able to drop the
 *  colliders for each prefab into the colliders list in the XR Interactable that
 *  you are using. This script only serves as a way to generate those notches.
 *  Once its done then it can be disabled on the turntable asset in the inspector.
*/
// [ExecuteAlways]
public class TurntableVisuals : MonoBehaviour
{
    [SerializeField]
    private Transform visualParent;

    [SerializeField]
    private GameObject dashPrefab;

    [SerializeField]
    private int segments = 36;

    [SerializeField]
    private float radius = 0.3f;

    // [SerializeField, Range(0.4f, 1.2f)]
    // private float tableHeight = 0.6f;

    void OnEnable()
    {
        GenerateNotches();
    }

    // Creates the prefabs around the turntable ring that are used for making it rotate.
    private void GenerateNotches()
    {
        float angleStep = 360f / segments;
        for (int i = 0; i < segments; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 position = new Vector3(x, visualParent.position.y - 0.12f, z);

            GameObject instance = Instantiate(
                dashPrefab,
                position,
                Quaternion.identity,
                visualParent
            );
            instance.transform.localPosition = position;
            instance.transform.LookAt(visualParent);

            // Each prefab needed a post Instantiation adjustment to make them face the correct position.
            // For some reason it didn't matter which way the prefab was rotated prior, it always sat reversed.
            Vector3 adjustedXRot = instance.transform.eulerAngles;
            adjustedXRot.x = -45f;
            instance.transform.eulerAngles = adjustedXRot;
        }
    }

    // void OnDisable()
    // {
    //     foreach (Transform child in transform)
    //     {
    //         Destroy(child);
    //     }
    // }
}
