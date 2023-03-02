using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] private Transform mouse;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Camera camera;

    [SerializeField] private Sprite cursor;
    [SerializeField] private Sprite handCursor;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        offset = new Vector3(-3, 1, 0); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IWindowsObject windowsObject))
            spriteRenderer.sprite = handCursor;
        else spriteRenderer.sprite = cursor;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IWindowsObject windowsObject))
            spriteRenderer.sprite = cursor;
    }

    public void SetPosition(Vector3 mousePos)
    {
        if (FindObjectOfType<StartPCButton>().IsWork())
        {
            mousePos.z = transform.position.z;
            transform.position = mousePos + offset;
            CheckBoundaries();
        }

    }

    private void CheckBoundaries()
    {
        if (transform.position.x < -0.25f)
        {
            transform.position = new Vector3(-0.25f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 2.652621f - 0.052621f)
        {
            transform.position = new Vector3(2.652621f - 0.052621f, transform.position.y, transform.position.z);
        }

        if (transform.position.y < -2.917876f + 4.317876f)
        {
            transform.position = new Vector3(transform.position.x, -2.917876f + 4.317876f, transform.position.z);
        }
        else if (transform.position.y > 2.917876f - 0.057876f)
        {
            transform.position = new Vector3(transform.position.x, 2.917876f - 0.057876f, transform.position.z);
        }
    }

    public bool CursorInEmpty()
    {
        return transform.localPosition.x >= 0.5f;
    }
}
