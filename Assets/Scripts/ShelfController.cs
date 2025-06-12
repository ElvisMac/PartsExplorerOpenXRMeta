using System.Collections;
using UnityEngine;

/*
 * This needs a reference to the animator that contains the desired movement of the object
 * that the script is attached to.  It will then set a truthy state in the animator to 
 * trigger the forward or reverse of the desired animation.
 */
public class ShelfController : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    GameObject shelves;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TriggerShelves()
    {
        if (animator.GetBool("isOpen") == false)
        {
            animator.SetBool("isOpen", true);
        }
        else
        {
            animator.SetBool("isOpen", false);
        }
    }

}
