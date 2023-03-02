using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RAM : Interactable
{
    public UnityEvent OnMouseEnterInRAM;
    public UnityEvent OnMouseExitInRAM;
    public override void OnMouseEnter()
    {
        if (cameraMove.IsStartPosition() == false)
        {
            outline.OutlineWidth = 7;
            OnMouseEnterInRAM.Invoke();
            OnMouseEnterOnInteractableObject.Invoke();
        }
    }

    public override void OnMouseExit()
    {
        base.OnMouseExit();
        OnMouseExitInRAM.Invoke();
    }

    public override void SwitchOutline()
    {
        outline.OutlineWidth = 0;
    }
}
