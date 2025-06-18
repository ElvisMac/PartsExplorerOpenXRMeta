using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AssemblySO : ScriptableObject {
    public string itemName;
    [TextArea(10, 100)]
    public string itemDescription;
}