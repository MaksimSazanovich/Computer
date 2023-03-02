using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public abstract class Interactable : MonoBehaviour
{
    protected Outline outline;
    protected InformationTrigger trigger;

    public UnityEvent OnMouseEnterOnInteractableObject;
    public UnityEvent OnMouseExitOnInteractableObject;

    [SerializeField] protected CameraMove cameraMove;
    [SerializeField] protected BoxCollider boxCollider;
    void Awake()
    {
        outline = GetComponent<Outline>();
        trigger = GetComponent<InformationTrigger>();
        outline.OutlineWidth = 0;
    }

    public abstract void OnMouseEnter();


    public virtual void OnMouseExit()
    {
        outline.OutlineWidth = 0;
        OnMouseExitOnInteractableObject.Invoke();
    }

    public abstract void SwitchOutline();

    public virtual void ActivateOutline()
    {
        outline.enabled = true;
    }

    public virtual void DeactivateOutline()
    {
        outline.enabled = false;
    }

    public virtual void ActivateCollider()
    {
        boxCollider.enabled = true;
    }

    public virtual void DeactivateCollider()
    {
        boxCollider.enabled = false;
    }
}
