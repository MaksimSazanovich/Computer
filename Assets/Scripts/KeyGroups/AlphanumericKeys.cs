using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphanumericKeys : Interactable
{
    [SerializeField] private MeshCollider meshCollider;
    public override void OnMouseEnter()
    {
        if (cameraMove.IsStartPosition() == false)
        {
            outline.OutlineWidth = 5;
            OnMouseEnterOnInteractableObject.Invoke();

        }
    }

    public override void SwitchOutline()
    {
        outline.OutlineWidth = 5;
    }

    public override void ActivateCollider()
    {
        meshCollider.enabled = true;
    }

    public override void DeactivateCollider()
    {
        meshCollider.enabled = false;
    }
}
