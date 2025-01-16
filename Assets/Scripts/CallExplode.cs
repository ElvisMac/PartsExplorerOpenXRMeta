using UnityEngine;

public class CallExplode : MonoBehaviour
{
    public void ExplodeComponent()
    {
        Debug.Log("Attempting to push the button.");
        AllEventsMgr.ToggleExplode();
    }
}
