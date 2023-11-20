using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToggleStudy : MonoBehaviour
{
    private Toggle[] toggles;
    private ToggleGroup toggleGroup;
    private ScrollRect[] scrollRects;
    bool isInit=false;
    private GameObject ScrollGroup;
    // Start is called before the first frame update
    void Start()
    {
        if (isInit)
        {
            //不知道为什么Start函数会运行两遍，虽然不影响结果
            return;
        }
        isInit = true;   
        toggleGroup = this.GetComponent<ToggleGroup>();
        toggles=transform.GetComponentsInChildren<Toggle>(true);
        ScrollGroup = GameObject.Find("ScrollViewGroup");
        scrollRects=ScrollGroup.GetComponentsInChildren<ScrollRect>();
        
        for(int i=0; i<scrollRects.Length; i++)
        {
            Text text = scrollRects[i].GetComponentInChildren<Text>();
            text.text=i.ToString();
            Image image = scrollRects[i].content.GetComponentInChildren<Image>();
            int f = Random.Range(0, 2);
            if (f == 0)
            {
                //没来
                image.color = Color.red;
            }
            else
            {
                image.color= Color.green;
            }

            scrollRects[i].gameObject.SetActive(false);
        }

        
        for (int i = 0;i<toggles.Length;i++)
        {
            toggles[i].GetComponentInChildren<Text>().text = (i+1).ToString();
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

    void ToggleValueChanged(Toggle toggle)
    {
        if (toggle.isOn)
        {

            
            int v = int.Parse(toggle.name);
            
            for (int i=0;i<24;i++)
            {
                GameObject g = ScrollGroup.transform.Find("s" + (i+1).ToString()).gameObject;
                if (i == v - 1)
                {
                    g.SetActive(true);
                }
                else
                {
                    g.SetActive(false);
                }
            }
           
        }
    }
}
