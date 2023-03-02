using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform startTarget;

    [SerializeField] private Keyboard keyboard;
    [SerializeField] private Mouse mouse;
    [SerializeField] private Printer printer;

    void Start()
    {
        SetStartTarget();
    }

    void Update()
    {
        transform.LookAt(target);
    }

    public void SetTarget(string name)
    {
        switch (name)
        {
            case "keyboard":
                target = keyboard.transform;
            break;
            case "mouse":
                target = mouse.transform;
                break;
            case "other":
                target = startTarget;
                break;
            case "printer":
                target = printer.transform;
                break;
            default:
                target = startTarget;
                break;
        }
    }

    public void SetStartTarget()
    {
        target = startTarget;
    }
}
