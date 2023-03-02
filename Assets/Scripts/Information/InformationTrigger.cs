using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationTrigger : MonoBehaviour
{    
    [SerializeField] private Information information;

    public void TriggerInformation()
    {
        FindObjectOfType<InformationManager>().ShowInformation(information);
    }
}
