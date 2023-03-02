using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WindowsReloadButton : MonoBehaviour, IWindowsObject
{
    [SerializeField] private Animator animator;

    [SerializeField] private UnityEvent ReloadPC;

    private bool cursorEnterButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Cursor cursor))
        {
            cursorEnterButton = true;
            animator.SetBool("isHighlighted", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Cursor cursor))
        {
            cursorEnterButton = false;
            animator.SetBool("isHighlighted", false);
        }
    }

    public void CheckReloadPC()
    {
        if (cursorEnterButton)
        {
            ReloadPC.Invoke();
        }
    }
}
