using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SVGImage SVGImage;
    [SerializeField] private TMP_Text backText;   

    private Color highlightedColor = new Color (1f,1f,1f, 0.418f);


    public void SetHighlightedColor()
    {
        SVGImage.color = highlightedColor;
        animator.SetTrigger("Normal");
        gameObject.SetActive(false);
    }

    public void ShowText(string text)
    { 
    backText.text = text;
    }

    public void ChooseAction()
    {
        if (backText.text == "Назад")
        {
            FindObjectOfType<CameraMove>().StartCoroutine();
        }
        else if (backText.text == "Выйти") FindObjectOfType<LevelManager>().LoadMenu();
    }
}
