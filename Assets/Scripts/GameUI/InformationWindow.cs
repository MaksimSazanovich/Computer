using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationWindow : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    private const int StartHeight = 35;
    [SerializeField] private int sentenceHeight = 15;
    private int height;

    private void Start()
    {
        SetStartHeight();
        height = StartHeight;
    }

    public void IncreaseHeight()
    {
        rectTransform.sizeDelta = new Vector2(176.9194f, height += sentenceHeight);
    }

    public void SetStartHeight()
    {
        rectTransform.sizeDelta = new Vector2(176.9194f, StartHeight);
        height = StartHeight;
    }
}
