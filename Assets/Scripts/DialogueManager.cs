using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    [SerializeField] TextMeshProUGUI m_dialogueText;
    [SerializeField] int m_index = -1;
    [SerializeField] float m_wordSpeed = 0.05f;
    [SerializeField] float m_lineSpeed = 0.2f;
    public GameEvent OnGoToNextLetter;
    public GameEvent onDialogEnd;


    IEnumerator Typing()
    {
        foreach(char letter in dialogue.GetCurrentLine(m_index).ToCharArray())
        {
            OnGoToNextLetter.Raise();
            m_dialogueText.text += letter;
            yield return new WaitForSeconds(m_wordSpeed);
        }

        if(m_dialogueText.text == dialogue.GetCurrentLine(m_index))
        {
            yield return new WaitForSeconds(m_lineSpeed);
            GoToNextLine();
        }
    }

    public void GoToNextLine()
    {
        if(m_index < dialogue.GetArrayLength()-1)
        {
            m_index++;
            m_dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            ResetDialogue();
            onDialogEnd.Raise();
        }
    }

    public void ResetDialogue()
    {
        m_dialogueText.text = "";
        m_index = -1;
    }

}
