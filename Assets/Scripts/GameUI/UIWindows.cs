using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindows : MonoBehaviour
{
    [SerializeField] private Vector3 nearMainComponents;

    [SerializeField] private Vector3 posNearPCComponents;
    [SerializeField] private Vector3 scaleNearPCComponents;

    [SerializeField] private Vector3 nearKeyboard;
    [SerializeField] private Vector3 scaleNearKeyBoard;

    [SerializeField] private Vector3 defaulteScalse;
    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetSettings(string name)
    {
        switch (name)
        {
            case "MainComponents":
                transform.localPosition = nearMainComponents;
                rectTransform.localScale = defaulteScalse;
                break;
            case "PCComponents":
                transform.localPosition = posNearPCComponents;
                rectTransform.localScale = scaleNearPCComponents;
                Debug.Log("PCComponents");
                break;
            case "Keyboard":
                rectTransform.localPosition = nearKeyboard;
                rectTransform.localScale = scaleNearKeyBoard;
                
                break;
        }
    }
}
