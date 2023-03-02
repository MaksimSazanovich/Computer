using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private Camera camera;
    [SerializeField] private Transform target;

    private void Start()
    {
        camera = Camera.main;
    }
    private void Update()
    {
        Vector3 screenMousePosition = Input.mousePosition;
        Vector3 worldMousePosition = camera.ScreenToWorldPoint(screenMousePosition);
        transform.LookAt(screenMousePosition);
        Debug.Log($"rotate {worldMousePosition}");
    }
}
