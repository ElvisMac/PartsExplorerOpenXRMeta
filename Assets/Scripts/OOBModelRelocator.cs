using UnityEngine;

public class OOBModelRelocator : MonoBehaviour
{
    [SerializeField]
    private GameObject relocator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = relocator.transform.position;
    }
}
