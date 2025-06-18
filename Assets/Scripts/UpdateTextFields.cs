using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 * Attaches to the UI element in the scene that displays the information 
 * that is attached to the item being hovered on when a model is exploded
 * on the turntable. This is done using the AllEventsManager static 
 * class.
 */
public class UpdateTextFields : MonoBehaviour
{
    [SerializeField]
    private TMP_Text title;

    [SerializeField]
    private TMP_Text description;

    // Start is called before the first frame update
    void Start()
    {
        title.text = string.Empty;
        description.text = "Information will appear here once you hover over a component part...";
    }

    void OnEnable()
    {
        AllEventsMgr.OnPartHover += UpdateTextElements;
    }

    void OnDisable()
    {
        AllEventsMgr.OnPartHover -= UpdateTextElements;
    }

    public void UpdateTextElements(string title, string description)
    {
        this.title.text = title;
        this.description.text = description;
    }
}
