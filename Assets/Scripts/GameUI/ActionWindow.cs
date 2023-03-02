using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionWindow : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private  float StartWidth = 1f;
    [SerializeField] private  float DefaultWight = 0.04f;
    [SerializeField] private float sentenceWight = 0.06f;
    [SerializeField] private float wight;
    [SerializeField] private float height;   
    private int numberOfLetters = 0;
    private int numberOfLetters�ounted = 0;

    [SerializeField] private TMP_Text actionText;

    private void Start()
    {
        wight = StartWidth;
    }

    public void Show(string action)
    {
        if (action == "����������" && FindObjectOfType<StartPCButton>().IsWork())
        {
            action = "���������";
        }
        else if (action == "����������" && FindObjectOfType<StartPCButton>().IsWork()== false) action = "��������";

        if (action == "���������������" && FindObjectOfType<PrinterStartButton>().IsWork())
        {
            action = "���������";
        }
        else if (action == "���������������" && FindObjectOfType<PrinterStartButton>().IsWork() == false) action = "��������";
        actionText.text = action;
        SetWight(action);
    }



    public void SetWight(string action)
    {
        char[] letters = action.ToCharArray();
        for (int i = 0; i < letters.Length; i++)
        {
            numberOfLetters++;
            if (numberOfLetters == 3)
            {
                wight += sentenceWight;
                numberOfLetters = 0;
                numberOfLetters�ounted += 3;
            }


        }
        if (letters.Length - numberOfLetters�ounted <= 2)
        {
            wight += sentenceWight;
        }
        rectTransform.localScale = new Vector2(wight, height);
    }

    public void SetStartWight()
    {
        wight = DefaultWight;
        rectTransform.localScale = new Vector2(wight, height);
    }
}
