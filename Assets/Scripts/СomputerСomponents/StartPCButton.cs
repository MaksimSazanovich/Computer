using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StartPCButton : Interactable
{
    public UnityEvent OnMouseEnterStartPCButton;
    public UnityEvent OnMouseExitStartPCButton;
    public UnityEvent StartPC;
    public UnityEvent OffPC;

    [SerializeField] private Animator animator;

    private bool isWork;

    private void Start()
    {
        isWork = false;
    }
    public bool IsWork()
    {
        return isWork;
    }
    public override void OnMouseEnter()
    {
        if (cameraMove.IsStartPosition())
        {
            outline.OutlineWidth = 7;
            OnMouseEnterOnInteractableObject.Invoke();
            OnMouseEnterStartPCButton.Invoke();
        }
    }

    public override void SwitchOutline()
    {
        outline.OutlineWidth = 0;
    }

    public override void OnMouseExit()
    {
        base.OnMouseExit();
        OnMouseExitStartPCButton.Invoke();
    }

    private void OnMouseDown()
    {
        if (isWork)
        {
            animator.SetTrigger("Click");
            OffPc();
        }          
        else
        {
            animator.SetTrigger("Click");
            StartPC.Invoke();
            isWork = true;
        }
    }

    public void OffPc()
    {
        isWork = false;
        OffPC.Invoke();
    }

    public void ReloadPC()
    {
        OffPC.Invoke();
        Invoke("StartPc", 2f);
    }

    private void StartPc()
    {
        StartPC.Invoke();
    }
}
