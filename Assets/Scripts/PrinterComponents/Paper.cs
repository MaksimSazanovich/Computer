using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Paper : MonoBehaviour
{
    [SerializeField] private Transform pointForClearPaper;
    [SerializeField] private Transform pointForColorPaper;
    [SerializeField] private UnityEvent OnPrintFinished;
    private float speed=0.1f;

    private void Start()
    {
        SetPoint(name);
    }

    public void SetPoint(string name)
    {
        if (name == "ClearPaper")
        {
            transform.LookAt(pointForClearPaper);
        }
        else if (name == "ColorPaper")
        {
            transform.LookAt(pointForColorPaper);
        }
    }

    public void StartCoroutine(Transform point)
    {
        StartCoroutine(Move(point));
    }
    public IEnumerator Move(Transform newpoint)
    {
        yield return new WaitForSeconds(2.9f);
        transform.DOMove(newpoint.position, 9f).SetEase(Ease.Linear).OnComplete(InvokeOnPrintFinished);
    }

    private void InvokeOnPrintFinished()
    {
        OnPrintFinished.Invoke();
    }
}
