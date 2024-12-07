using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAlignment : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPrefab;

    [SerializeField]
    private GameObject targetParent;

    [SerializeField]
    private List<InventoryItemSO> inventoryItems;

    private float xOffsetStart = 30f;
    private float yOffsetStart = -30f;

    //private float padding = 1f;
    private float spacing = 60f;

    // Start is called before the first frame update
    void Start()
    {
        foreach (InventoryItemSO item in inventoryItems)
        {
            GameObject newButton = Instantiate(buttonPrefab, targetParent.transform);
            //newButton.GetComponentInChildren<InteractionButton>().OnPress += () => ButtonAction(item.prefab);
            //buttonPrefab.GetComponent<InteractionButton>().manager = interactionManager;

            Vector3 offset = new Vector3(xOffsetStart, yOffsetStart, -5);
            newButton.transform.localPosition = newButton.transform.localPosition + offset;
            if (xOffsetStart >= xOffsetStart + (spacing * 3))
            {
                xOffsetStart = 30f;
                yOffsetStart -= spacing;
            }
            else
            {
                xOffsetStart += spacing;
            }
        }
    }

    private void ButtonAction(GameObject objectToLoad)
    {
        Debug.Log("This will load " + objectToLoad.name);
    }

    // Update is called once per frame
    void Update() { }

    public void ToggleInventory()
    {
        if (this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
