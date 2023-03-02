using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WindowsStart : MonoBehaviour, IWindowsObject
{
    [SerializeField] private Animator animator;
    [SerializeField] private UnityEvent OnClickButton;
    [SerializeField] private UnityEvent OnClickEmpty;
    [SerializeField] private Cursor cursor;

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

    public void CheckStartButton()
    {
        if (cursorEnterButton)
        {
            OnClickButton.Invoke();
        }
        else if (cursor.CursorInEmpty())
        { 
            OnClickEmpty.Invoke();
            EndHighlighted();
        }
    }

    public void EndHighlighted()
    {
        animator.SetBool("isHighlighted", false);
    }
}
