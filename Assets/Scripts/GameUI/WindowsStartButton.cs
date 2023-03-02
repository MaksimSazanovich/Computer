using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsStartButton : MonoBehaviour
{
    private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Cursor cursor))
        animator.SetTrigger("Highlighted");
    }
}
