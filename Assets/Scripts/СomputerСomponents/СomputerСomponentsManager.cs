using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СomputerСomponentsManager : MonoBehaviour
{
    public void SwitchComputerCOmponents(Interactable[] computerComponents, bool isEnabled)
    {
        foreach (var component in computerComponents)
        {
            component.enabled = isEnabled;
        }
    }
}
