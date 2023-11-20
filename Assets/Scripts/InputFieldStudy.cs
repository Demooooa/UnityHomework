using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldStudy : MonoBehaviour
{
    private ToggleGroup toggleGroup;
    private InputField inputField;
    private Toggle[] toggles;
    private GameObject ScrollGroup;
    private Scrollbar scrollbar;
    int v;
    int seatIndex;
    int rowIndex;
    float value;
    void Start()
    {
        toggleGroup=GameObject.Find("ToggleGroup").GetComponent<ToggleGroup>();
        inputField = GetComponent<InputField>();
        ScrollGroup = GameObject.Find("ScrollViewGroup");
        inputField.onEndEdit.AddListener(EndEdit);
        toggles=toggleGroup.GetComponentsInChildren<Toggle>();
        for(int i = 0; i < toggles.Length; i++)
        {
            addListener(toggles[i]);

        }
    }

    void addListener(Toggle toggle)
    {
        toggle.onValueChanged.AddListener(ifselect => {
            if (ifselect)
                ToggleValueChanged(toggle);
        });
    }
    private void EndEdit(string s)
    {
        v=int.Parse(s);
        seatIndex = v - 1; //从0开始计数，所以需要减去1  
        rowIndex = seatIndex / 6; //计算行索引   

        //找到对应的Toggle并触发OnValueChanged事件  
        toggles[rowIndex].isOn = true;
        ToggleValueChanged(toggles[rowIndex]);
    }

    void ToggleValueChanged(Toggle toggle)
    {
        if (toggle.isOn)
        {
            int v = int.Parse(toggle.name);
            for (int i = 0; i < 4; i++)
            {
                GameObject g = ScrollGroup.transform.Find("s" + (i + 1).ToString()).gameObject;
                if (i == v - 1)
                {
                    scrollbar = g.GetComponentInChildren<Scrollbar>();
                    value = (((seatIndex+1) )% 6)/6f;
                    scrollbar.value = value;
                    g.SetActive(true);
                }
                else
                {
                    g.SetActive(false);
                }
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
