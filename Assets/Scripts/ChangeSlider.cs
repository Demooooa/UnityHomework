using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeSlider : MonoBehaviour
{
    private Slider slider;
    private Button hadle;
    void Start()
    {
        hadle=this.GetComponent<Button>();
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        hadle.onClick.AddListener(OnHandleClick);
    }

    void OnHandleClick()
    {
        if(slider.value==slider.maxValue)
        {
            slider.value=slider.minValue;
        }
        else if(slider.value==slider.minValue)
        {
            slider.value=slider.maxValue;
        }
        else
        {
            slider.value=slider.minValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
