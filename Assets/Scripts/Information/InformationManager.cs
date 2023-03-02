using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class InformationManager : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text informationText;
    [SerializeField] NameWindow nameWindow;
    private Queue<string> sentenses;
    private int numberOfLetters = 0;

    public UnityEvent NewLine;
    void Start()
    {
        sentenses = new Queue<string>();
    }

    public void ShowInformation(Information information)
    {
        sentenses.Clear();
        nameText.text = information.name;

        foreach (string sentence in information.sentences)
        {
            sentenses.Enqueue(sentence);
        }
        nameWindow.SetWight(information.name.ToCharArray());
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentenses.Count == 0)
        {
            HideInformation();
            return;
        }

        string sentence = sentenses.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentense(sentence));
    }

    IEnumerator TypeSentense(string sentence)
    {
        informationText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            informationText.text += letter;
            numberOfLetters++;
            if (numberOfLetters >= 32)
            {
                numberOfLetters = 0;
                NewLine.Invoke();
            }
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void HideInformation()
    {
        StopAllCoroutines();
        informationText.text = "";
        nameText.text = "";
    }

    public char[] CharsInName(Information information)
    {
        return information.name.ToCharArray();
    }
}
