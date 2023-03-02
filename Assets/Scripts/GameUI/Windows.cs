using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windows : MonoBehaviour
{
    [SerializeField] private GameObject windows;

    private void Start()
    {
        windows.SetActive(false);
    }
    public void Activate()
    {
        windows.SetActive(true);
    }

    public void Diactivate()
    {
        windows.SetActive(false);
    }
}
