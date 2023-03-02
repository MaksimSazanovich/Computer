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
    private int numberOfLettersСounted = 0;

    [SerializeField] private TMP_Text actionText;

    private void Start()
    {
        wight = StartWidth;
    }

    public void Show(string action)
    {
        if (action == "ВключитьПК" && FindObjectOfType<StartPCButton>().IsWork())
        {
            action = "Выключить";
        }
        else if (action == "ВключитьПК" && FindObjectOfType<StartPCButton>().IsWork()== false) action = "Включить";

        if (action == "ВключитьПринтер" && FindObjectOfType<PrinterStartButton>().IsWork())
        {
            action = "Выключить";
        }
        else if (action == "ВключитьПринтер" && FindObjectOfType<PrinterStartButton>().IsWork() == false) action = "Включить";
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
                numberOfLettersСounted += 3;
            }


        }
        if (letters.Length - numberOfLettersСounted <= 2)
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
