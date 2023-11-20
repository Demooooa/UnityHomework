using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStudy : MonoBehaviour
{
    public GameObject[] cubes = new GameObject[4];
    public Canvas[] canvas = new Canvas[4];

    private float[] speeds;
    private float[] rotations;

    private void Start()
    {
        speeds = new float[cubes.Length];
        rotations = new float[cubes.Length];
        // 初始化Cube的位置和速度
        for (int i = 0; i < 4; i++)
        {
            cubes[i].transform.position = new Vector3(0, 0, Random.Range(0f, 10f));
            speeds[i] = Random.Range(1f, 4f);
        }
    }

    private void Update()
    {
        // 移动Cube
        for (int i = 0; i < 4; i++)
        {
            cubes[i].transform.Translate(0, 0, speeds[i] * Time.deltaTime, Space.World);
            cubes[i].transform.Rotate(0, Random.Range(90f, 120f) * Time.deltaTime, 0, Space.Self);
            canvas[i].sortingOrder = (int)cubes[i].transform.position.z;
            // 检查是否超出范围，超出则重新设置速度
            if (cubes[i].transform.position.z >= 10f || cubes[i].transform.position.z <= 0f)
            {

                speeds[i] = -speeds[i];
            }
        }
    }
}
