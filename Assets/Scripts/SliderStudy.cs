using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderStudy : MonoBehaviour
{
    private Slider slider;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        text=GameObject.Find("text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text="Cube的旋转速度为:"+slider.value;
       this.transform.Rotate(0,slider.value*Time.deltaTime,0,Space.World);
    }
}
