using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMenu : MonoBehaviour
{

    private GameObject currentDisplay;
    private GameObject PanelManager;
    private Dropdown dropdown;

    public int dropdownValue = 0;

    void Awake()
    {
        PanelManager = GameObject.Find("PanelManager");

        SetDropdown();

        dropdown.value = dropdownValue;

        if (dropdown.value != 0)
        {
            OnValueChanged(dropdownValue);
        }
    }

    void Update()
    {
        dropdown.value = dropdownValue;
    }

    [ContextMenu("SetMenu")]
    void SetMenu()
    {
        if (dropdownValue < 0) return;

        PanelManager = GameObject.Find("PanelManager");

#if UNITY_EDITOR
        SetDropdown();
#endif

        dropdown.value = dropdownValue;

        OnValueChanged(dropdownValue);
    }

    public void OnValueChanged(int result)
    {
        //Debug.Log(result);
        if (result < 0 || result >= dropdown.options.Count) return;

        //再起動用
        if (!currentDisplay)
        {
            if(this.transform.GetChild(0).gameObject.name != "Menu")
            {
                currentDisplay = this.transform.GetChild(0).gameObject;
            }
        }

        //非表示処理
        if (dropdown.value == 0)
        {
            if (currentDisplay) DestroyImmediate(currentDisplay);
            currentDisplay = null;
        }
        else
        {
            if (currentDisplay)
            {
                if (currentDisplay.name != "Menu")
                {
                    if (currentDisplay.Equals(PanelManager.transform.GetChild(dropdown.value - 1).gameObject))
                    {
                        return;
                    }
                }
                DestroyImmediate(currentDisplay);
            }

            //表示処理
            // Debug.Log(PanelManager.transform.GetChild(dropdown.value - 1).gameObject.name);
            currentDisplay = Instantiate(PanelManager.transform.GetChild(dropdown.value - 1).gameObject) as GameObject;

            currentDisplay.transform.parent = this.transform;
            //表示順調整
            currentDisplay.transform.SetSiblingIndex(0);

            RectTransform rect = currentDisplay.GetComponent<RectTransform>();
            rect.localPosition = Vector3.zero;
            rect.localScale = new Vector3(1, 1, 1);
        }
    }

    void SetDropdown()
    {
        dropdown = this.transform.GetChild(0).GetComponent<Dropdown>();
        if(!dropdown) dropdown = this.transform.GetChild(1).GetComponent<Dropdown>();

        dropdown.ClearOptions();

        dropdown.options.Add(new Dropdown.OptionData { text = "None" });
        foreach(Transform option in PanelManager.GetComponentsInChildren<Transform>())
        {
            if (option.name == "PanelManager") continue;
            dropdown.options.Add(new Dropdown.OptionData { text = option.name });
        }
    }
}
