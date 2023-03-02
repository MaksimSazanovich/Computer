using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameWindow : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    private const float StartWidth = 2f;
    private const float DefaultWight = 0.2f;
    [SerializeField] private float sentenceWight = 0.4f;
    private float wight;
    private int numberOfLetters = 0; 

    private void Start()
    {
        wight = StartWidth;
    }
    private void Update()
    {
        
    }

    public void SetWight(char[] letters)
    {
        for (int i = 0; i <  letters.Length; i++)
        {
            numberOfLetters++;
            if (numberOfLetters == 3)
            {
                wight += sentenceWight;
                numberOfLetters = 0;
            }           
        }
        rectTransform.localScale = new Vector2(wight, 1.096794f);
    }

    public void SetStartWight()
    {
        wight = DefaultWight;
        rectTransform.localScale = new Vector2(wight, 1.096794f);
    }
}
