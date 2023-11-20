using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageStudy : MonoBehaviour
{
    private Image image;
    float timer = 0;
    bool isChage=false;
    // Start is called before the first frame update
    void Start()
    {
        image=GameObject.Find("image").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (image.fillAmount == 1)
        {
            isChage = true;
        }
        if(image.fillAmount == 0)
        {
            isChage = false;
        }
        if(!isChage)
        {
            image.fillClockwise = true;
            image.fillAmount = timer / 2;
        }
        if(isChage)
        {
            image.fillClockwise = false;
            image.fillAmount = 1-timer / 2;
        }
        if(timer >= 2.0f)
        {
            timer = 0;
        }
    }
}
