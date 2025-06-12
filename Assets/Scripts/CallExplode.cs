using UnityEngine;

/*
 * Simple class that triggers toggle explode.  This was created so it can 
 * be attached to a button or interaction that will trigger a model to 
 * blow apart or return to its assembled state.
 */
public class CallExplode : MonoBehaviour
{
    public void ExplodeComponent()
    {
        Debug.Log("Attempting to push the button.");
        AllEventsMgr.ToggleExplode();
    }
}
