using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

[ExecuteAlways]


public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform p0;
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;
    [SerializeField] private Transform p3;

    [SerializeField] private Transform[] PCpoints;
    [SerializeField] private Transform[] keyboardPoints;
    [SerializeField] private Transform[] monitorPoints;
    [SerializeField] private Transform[] mousePoints;
    [SerializeField] private Transform[] printerPoints;
    private Transform[] currentPoints;

    [Range(0, 1)]
    [SerializeField] private float t;

    [SerializeField] private Vector3 startPos;

    [SerializeField] BackButton backButton;

    private bool goForward;

    public UnityEvent OnCameraOnStartPosition;
    public UnityEvent OnCameraOnOtherPosition;
    public UnityEvent OnCameraNearPC;
    [SerializeField] private UnityEvent OnCameraNearKeyboard; 
    public UnityEvent OnCameraMove;

    private void Awake()
    {
        transform.position = startPos;
        t = 0;
        goForward = true;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && t >= 0.9 || Input.GetKeyDown(KeyCode.Escape) && t >= 0.9)
        {
            goForward = false;
            StartCoroutine(Move());
            backButton.SetHighlightedColor();
            backButton.gameObject.SetActive(false);
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
        OnCameraMove.Invoke();
        for (int i = 0; i <= 99; i++)
        {
            if (goForward == true)
                t += 0.01f;
            else t -= 0.01f;

            yield return new WaitForSeconds(0.0011f);
            transform.position = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, t);
        }

        if (goForward == true)
        { 
            goForward = false;
            OnCameraOnOtherPosition.Invoke();
        }
        else
        {
            goForward = true;
            OnCameraOnStartPosition.Invoke();
        }

    }



    public void StartCoroutine()
    {
        StartCoroutine(Move());
    }

    public bool IsStartPosition()
    {
        return startPos == transform.position;
    }

    public void SetPoints(Transform[] points)
    {      
        p1 = points[0];
        p2 = points[1];
        p3 = points[2];
        StartCoroutine(Move());
    }



    public void ArrayPoints(string name)
    {
        switch (name)
        {
            case "pc":
                currentPoints = PCpoints;
                SetPoints(currentPoints);
                OnCameraNearPC.Invoke();
                break;
            case "keyboard":
                currentPoints = keyboardPoints;
                SetPoints(currentPoints);
                OnCameraNearKeyboard.Invoke();
                break;
            case "monitor":
                currentPoints = monitorPoints;
                SetPoints(currentPoints);
                break;
            case "mouse":
                currentPoints = mousePoints;
                SetPoints(currentPoints);
                break;
            case "printer":
                currentPoints = printerPoints;
                SetPoints(currentPoints);
                break;
            default:
                break;
        }
    }

}
