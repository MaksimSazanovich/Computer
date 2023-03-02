using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motherboard : Interactable
{
    [SerializeField] private BoxCollider boxCollider2;
    [SerializeField] private BoxCollider boxCollider3;
    public override void OnMouseEnter()
    {
        if (cameraMove.IsStartPosition() == false)
        {
            outline.OutlineWidth = 7;
            OnMouseEnterOnInteractableObject.Invoke();
        }
    }

    public override void SwitchOutline()
    {
        outline.OutlineWidth = 0;
    }

    public override void ActivateCollider()
    {
        base.ActivateCollider();
        boxCollider2.enabled = true;
        boxCollider3.enabled = true;
    }

    public override void DeactivateCollider()
    {
        base.DeactivateCollider();
        boxCollider2.enabled = false;
        boxCollider3.enabled = false;
    }
}
