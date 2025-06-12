using UnityEngine;

/*
 * There is a bounding trigger surrounding the scene that prevents the interactable 
 * and moveable gameobjects from being lost in the scene, preventing the need to 
 * reload in the event something falls through the floor.  This will target the item
 * that escapes the bounds and drop it in position over the top of the turntable.
 * The game object will maintain whatever direction of travel and velocity it was travelling
 * at until it slows down and hits a wall inside the "level".
 */
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
