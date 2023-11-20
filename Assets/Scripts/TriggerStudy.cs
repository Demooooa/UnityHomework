using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStudy : MonoBehaviour
{
    public Material[] materials;
    private float speed = 2.0f;
    private int colorIndex = 0;
    private int currentMaterialIndex = 0;
    Collider c;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeSphereMaterial());

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed*Time.deltaTime,0,0);
    }

    IEnumerator ChangeSphereMaterial()
    {
        while (true)
        {
            // 每隔0.5秒改变一次材质  
            yield return new WaitForSeconds(0.5f);

            this.GetComponent<Renderer>().material = materials[currentMaterialIndex];
            // 更新当前使用的材质索引，如果到了数组的末尾则回到开头  
            currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
        }
    }

    //改变方块的材质
    void ChangeMaterial()
    {
        // 切换材质  
        c.GetComponent<Renderer>().material = materials[colorIndex];
        colorIndex++; 
        if(colorIndex >= materials.Length)
        {
            colorIndex = 0;
        }
    }


    IEnumerator PauseForSeconds()
    {
        float s = speed;
        speed = 0;
        // 暂停1秒数 
        yield return new WaitForSeconds(1.0f);
        speed = -s;
    }

    private void OnTriggerEnter(Collider other)
    {
        c= other.GetComponent<Collider>();
        InvokeRepeating("ChangeMaterial", 0.5f, 0.5f);
    }

    private void OnTriggerExit(Collider other)
    {
        c = other.GetComponent<Collider>();
        CancelInvoke("ChangeMaterial");
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(PauseForSeconds());
    }


}
