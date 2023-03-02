using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PrinterIcon : MonoBehaviour, IWindowsObject
{
    [SerializeField] private GameObject outline;
    [SerializeField] private CameraMove cameraMove;
    [SerializeField] private PrinterStartButton printerStartButton;

    private bool isFirstPrint;
    private bool cursorEnterIcon;

    public UnityEvent Print;
    public UnityEvent OnMouseEnterPrinterIcon;
    public UnityEvent OnMouseExitPrinterIcon;
    void Start()
    {
        outline.SetActive(false);
        isFirstPrint = true;
        cursorEnterIcon = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Cursor cursor))
        {
            if (cameraMove.IsStartPosition())
            {
                cursorEnterIcon = true;
                outline.SetActive(true);
                if (printerStartButton.IsWork() && isFirstPrint)
                {
                    OnMouseEnterPrinterIcon.Invoke();
                }

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Cursor cursor))
        {
            cursorEnterIcon = false;
            outline.SetActive(false);
            OnMouseExitPrinterIcon.Invoke();
        }
    }



    public void CheckPrint()
    {
        if (printerStartButton.IsWork()  && isFirstPrint && cursorEnterIcon)
        {
            Print.Invoke();
            isFirstPrint = false;
        }
    }
}
