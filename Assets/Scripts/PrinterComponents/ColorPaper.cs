using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorPaper : Interactable
{
    [SerializeField] private Transform p0;
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;
    [SerializeField] private Transform p3;
    [SerializeField] private Transform target;
    [SerializeField] private Transform startTarget;

    [Range(0, 1)]
    [SerializeField] private float t;

    private bool inPrinter = true;
    private bool goForward;

    public UnityEvent ColorPaperInPrinter;

    private void Awake()
    {
        outline = GetComponent<Outline>();
        outline.OutlineWidth = 0;
        t = 0;
        goForward = true;
        ColorPaperInPrinter.Invoke();
    }
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

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && t >= 0.9 || Input.GetKeyDown(KeyCode.Escape) && t >= 0.9)
        {
            goForward = false;
            StartCoroutine(Move());
        }
        if (inPrinter == false)
        {
            transform.LookAt(target);
        }
    }
    private void OnDrawGizmos()
    {
        int sigmentsNumber = 20;
        Vector3 preveousPoint = p0.position;

        for (int i = 0; i < sigmentsNumber; i++)
        {
            float parameter = (float)i / sigmentsNumber;
            Vector3 point = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, parameter);
            Gizmos.DrawLine(preveousPoint, point);
            preveousPoint = point;
        }
    }

    public IEnumerator Move()
    {
        for (int i = 0; i <= 99; i++)
        {
            if (goForward == true)
                t += 0.01f;
            else t -= 0.01f;

            yield return new WaitForSeconds(0.0001f);
            transform.position = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, t);
        }

        if (goForward == true)
        {
            goForward = false;

        }
        else
        {
            goForward = true;
            inPrinter = true;
            transform.LookAt(startTarget);
        }
    }

    private void OnMouseDown()
    {
        if (cameraMove.IsStartPosition() && inPrinter)
        {
            StartCoroutine(Move());            
            inPrinter = false;
        }

    }

}
