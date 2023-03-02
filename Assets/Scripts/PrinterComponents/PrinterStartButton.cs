using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;

public class PrinterStartButton : Interactable
{
    [SerializeField] private Animator animator;

    private bool isWork = false;

    public UnityEvent StartPrinter;
    public UnityEvent StopPrinter;
    public override void OnMouseEnter()
    {
        if (cameraMove.IsStartPosition() == false)
        {
            outline.OutlineWidth = 3;
            OnMouseEnterOnInteractableObject.Invoke();
        }
    }

    public override void SwitchOutline()
    {
        outline.OutlineWidth = 0;
    }

    private void OnMouseDown()
    {
        if (cameraMove.IsStartPosition() == false)
        {
            animator.SetTrigger("Click");
            StartPrinter?.Invoke();
            if (isWork)
            {
                animator.SetTrigger("Click");
                StopPrinter.Invoke();
                isWork = false;
            }
            else
            {
                animator.SetTrigger("Click");
                StartPrinter.Invoke();
                isWork = true;
            }
        }
    }

    public bool IsWork()
    { 
    return isWork;
    }
}
