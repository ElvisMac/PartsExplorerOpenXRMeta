using UnityEngine;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Interaction.Toolkit;

public class PokeRotation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    XRInteractionManager xrim;

    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void OnTriggerEnter()
    {
        Debug.Log("You fingered the thing...");
    }

    public void OnFingered(Collider collider)
    {
        Debug.Log("You fingered the thing...");
    }
}
