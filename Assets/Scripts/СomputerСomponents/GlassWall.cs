using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GlassWall : Interactable

{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject wall;


    public UnityEvent OnGlassWallStay;
    public UnityEvent OnGlassWallStayEnd;

    //private void Start()
    //{
    //    outline.OutlineWidth = 0;
    //    outline.enabled = false;
    //}
    private void Update()
    {
        //if (cameraMove.IsStartPosition() == false)
           // OnGlassWallStay.Invoke();
        

    }
    public override void SwitchOutline()
    {
        outline.OutlineWidth = 7;
    }

    public override void OnMouseEnter()
    {
        if (cameraMove.IsStartPosition() == false)
        {
            outline.OutlineWidth = 7;
            OnGlassWallStay.Invoke();
            OnMouseEnterOnInteractableObject.Invoke();
        }
    }

    private void OnMouseDown()
    {
        animator.SetTrigger("open");
        OnMouseExitOnInteractableObject.Invoke();
        StartCoroutine(StayEnd());
        
    }

    private void Deactivate()
    {
        wall.SetActive(false);
    }

    private IEnumerator StayEnd()
    {
        yield return new WaitForSeconds(0.9f);
        OnGlassWallStayEnd.Invoke();
        yield return new WaitForSeconds(0.2f);
        Invoke("Deactivate", 0.1f);
    }
}
