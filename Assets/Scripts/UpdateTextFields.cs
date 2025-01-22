using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
