using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class AudioListener : MonoBehaviour
{
    [SerializeField] private AudioSource pcWorkSound;
    [SerializeField] private AudioSource printerStartWorkSound;
    [SerializeField] private AudioSource printerPrintSound;
    
    public void PlaySound(string name)
    {
        switch (name)
        {
            case "pc":
                pcWorkSound.Play();
                break;
            case "printer":
                printerStartWorkSound.Play();
                break ;
            case "printerPrint":
                printerPrintSound.Play();
                break;          
            default:
                break;
        }

    }

    public void StopSound(string name)
    {
        switch (name)
        {
            case "pc":
                pcWorkSound.Stop();
                break;
            case "printer":
                printerStartWorkSound.Stop();
                break;
            case "prinerPrint":
                printerPrintSound.Stop();
                break;
            default:
                break;
        }
    }
}
