using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WindowsIcon : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public UnityEvent OnLoadEnd;
    public void Play()
    {
        animator.SetTrigger("Visible");
        StartCoroutine(SetMonitorActiveMaterial());
    }

    private IEnumerator SetMonitorActiveMaterial()
    {
        yield return new WaitForSeconds(6f);
        OnLoadEnd.Invoke();
    }
}
