using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewStudy : MonoBehaviour
{
    public GridLayoutGroup gridLayoutGroup;
    private ScrollRect scrollRect;
    public Image image;
    Button button;
    private bool isHorizontal=true;
    void Start()
    {
        GameObject p = GameObject.Find("Content");
        scrollRect =GameObject.Find("ScrollView").GetComponent<ScrollRect>();
        for (int i = 0; i < 30; i++)
        {
            Image image1=Instantiate(image);
            image1.transform.parent = p.transform;
            Text text=image1.GetComponentInChildren<Text>();
            text.transform.parent = image1.transform;
            //image1.color = Color.red;
            text.text = i.ToString();
        }

        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        isHorizontal=!isHorizontal;
        if(isHorizontal)
        {
            scrollRect.horizontal = false;
            scrollRect.vertical=true;
            gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayoutGroup.constraintCount = 1;
        }
        else
        {
            scrollRect.horizontal = true;
            scrollRect.vertical = false;
            gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            gridLayoutGroup.constraintCount = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
