using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    [SerializeField] Animator[] animators;
    public void Rotate()
    {
        foreach (Animator animator in animators)
        {
            animator.SetBool("isPCWork", true);
        }
        
    }

    public void EndRotation()
    {
        foreach (Animator animator in animators)
        {
            animator.SetBool("isPCWork", false);
        }
    }
}
