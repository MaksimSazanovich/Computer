using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : Interactable
{
    public override void SwitchOutline()
    {
        outline.OutlineWidth = 0;
    }

    public override void OnMouseEnter()
    {
        if (cameraMove.IsStartPosition())
        {
            outline.OutlineWidth = 4;
            OnMouseEnterOnInteractableObject.Invoke();
        }
    }
}
