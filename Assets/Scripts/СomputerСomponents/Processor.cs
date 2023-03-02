using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Processor : Interactable
{
    public UnityEvent OnMouseEnterInProcessor;
    public UnityEvent OnMouseExitInProcessor;
    public override void OnMouseEnter()
    {
        if (cameraMove.IsStartPosition() == false)
        {
            outline.OutlineWidth = 3;
            OnMouseEnterInProcessor.Invoke();
            OnMouseEnterOnInteractableObject.Invoke();
        }
    }

    public override void OnMouseExit()
    {
        base.OnMouseExit();
        OnMouseExitInProcessor.Invoke();
    }

    public override void SwitchOutline()
    {
        outline.OutlineWidth = 0;
    }
}
