using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    public UnityEvent<string> OnClick;
    [SerializeField] private CameraMove cameraMove;
    private void OnMouseDown()
    {
        if (cameraMove.IsStartPosition())
        {
            OnClick.Invoke(name);
        }
    }
}
