using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Mouse : Interactable
{


    private Vector3 cursorPosition;
    [SerializeField] private float cursorDistance;
    Vector3 objectPosition;
    [SerializeField] private UnityEvent<Vector3> OnMouseDraggged;
    [SerializeField] private UnityEvent OnMousePressed;
    [SerializeField] private Camera camera;
    public override void SwitchOutline()
    {
        outline.OutlineWidth = 0;
    }

    public override void OnMouseEnter()
    {
        if (cameraMove.IsStartPosition())
        {
            outline.OutlineWidth = 3;
            OnMouseEnterOnInteractableObject.Invoke();
        }
        
    }

    private void OnMouseDown()
    {
        OnMousePressed.Invoke();
    }

    //private void OnMouseDrag()
    //{
    //    objectPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
    //    objectPosition.y = transform.position.y;
    //    transform.position = GetMouseWorldPos() + mOffset;
    //}

    //private void OnMouseDown()
    //{
    //    cursorPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cursorDistance);
    //    objectPosition =  Camera.main.ScreenToWorldPoint(cursorPosition);
    //    mOffset = transform.position - objectPosition;
    //}

    //private Vector3 GetMouseWorldPos()
    //{

    //}

    private void OnMouseDrag()
    {
        cursorPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cursorDistance);
        objectPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
        OnMouseDraggged.Invoke(objectPosition);
        objectPosition.y = transform.position.y;
        transform.position = objectPosition;
    }

    private void Update()
    {
        CheckBoundaries();
    }

    private void CheckBoundaries()
    {
        if (transform.position.x < -13.50032f + 16.00032f)
        {
            transform.position = new Vector3(-13.50032f + 16.00032f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 13.50032f - 8.50032f)
        {
            transform.position = new Vector3(13.50032f - 8.50032f, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -2.845999f + 4.945999f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -2.845999f + 4.945999f);
        }
        else if (transform.position.z > 2.845999f - 0.345999f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 2.845999f - 0.345999f);
        }
    }
}
