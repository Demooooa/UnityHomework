using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAndText : MonoBehaviour
{
    public Button button;
    public Text text;
    public float textSpeed = 1f; // �ı���ʾ���ٶ�
    private string[] textPrint= { "2023��10��21��", "0210182" , "��녾�" };
    private string[] textStart= { "<size=32>", "<color=blue><size=16>", "<color=red><size=64>" };
    private string[] textEnd= { "</size>", "</size></color>", "</size></color>" };
    private float timer;//��ʱ��
    private bool isClicked;
    private float colorInterval = 10f; // ��ɫ�仯�ļ��
    private int currentPos = 0;//��ǰ����λ��

    int i = 0;
    string t;

    private void Start()
    {
        timer = 0;
        textSpeed = Mathf.Max(0.2f, textSpeed);
        button.onClick.AddListener(OnButtonClick);
    }

    private void Update()
    {
        // ��ת��ť
        if (!isClicked)
        {
            float rotation = Mathf.PingPong(Time.frameCount / 6f, 10f) - 5f;
            button.transform.rotation = Quaternion.Euler(button.transform.rotation.eulerAngles.x, button.transform.rotation.eulerAngles.y, rotation);
        }

        if (isClicked)
        {
            OnStartWriter();
        }

        // �Ŵ�ť
        if (isClicked && button.transform.localScale.x < 1.3f)
        {
            button.transform.localScale += new Vector3(0.3f / 9f, 0.3f / 9f, 0.3f / 9f);
        }

        // �任��ɫ
        if (isClicked)
        {
            float t = (Time.frameCount / colorInterval) % 7;
            Color color;
            if (t < 1)
            {
                color = Color.red;
            }
            else if (t < 2)
            {
                color = Color.Lerp(Color.red, Color.yellow, t - 1);
            }
            else if (t < 3)
            {
                color = Color.yellow;
            }
            else if (t < 4)
            {
                color = Color.Lerp(Color.yellow, Color.green, t - 3);
            }
            else if (t < 5)
            {
                color = Color.green;
            }
            else if (t < 6)
            {
                color = Color.Lerp(Color.green, Color.blue, t - 5);
            }
            else
            {
                color = Color.blue;
            }
            button.image.color = color;
        }
    }

    private void OnButtonClick()
    {
        isClicked = true;
        button.interactable = false;
        button.interactable = true;
    }

    //���ֻ�
    void OnStartWriter()
    {
        timer += Time.deltaTime;    
        if (timer >= textSpeed)
        {
            timer = 0;
            currentPos++;
            Debug.Log(i);
            text.text = t+textStart[i] + textPrint[i].Substring(0, currentPos) + textEnd[i];
            if (currentPos >= textPrint[i].Length)
            {
                i++;
                t = text.text+"_";
                timer = 0;
                currentPos = 0;
            }
            if (i > 2)
            {
                isClicked = false;
            }
        }
    }
}
