using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Net;

public class GroupOfButtons : MonoBehaviour
{
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;
    [SerializeField] private SpriteRenderer[] spriteRenderers;
    [SerializeField] private BoxCollider2D[] boxColliders2D;

    public void ShowButtons()
    {
        transform.DOLocalMove(endPos, 0.2f).OnComplete(ActivateCollider);
       foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;


    }

    public void HideButtons()
    {
        DisactivateCollider();
        transform.DOLocalMove(startPos, 0.2f);
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
    }

    private void ActivateCollider()
    {
        foreach (BoxCollider2D boxCollider2D in boxColliders2D)
            boxCollider2D.enabled = true;
    }

    private void DisactivateCollider()
    {
        foreach (BoxCollider2D boxCollider2D in boxColliders2D)
            boxCollider2D.enabled = false;
    }
}
