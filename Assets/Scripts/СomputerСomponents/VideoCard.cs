using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoCard : Interactable
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
