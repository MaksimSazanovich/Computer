using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooler : Interactable
{
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
}
