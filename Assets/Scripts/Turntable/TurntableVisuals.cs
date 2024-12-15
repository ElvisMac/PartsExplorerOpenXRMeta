using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

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

    [SerializeField, Range(0.4f, 1.2f)]
    private float tableHeight = 0.6f;

    void OnEnable()
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
