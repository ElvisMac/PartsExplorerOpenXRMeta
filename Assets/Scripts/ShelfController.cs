using System.Collections;
using UnityEngine;

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
