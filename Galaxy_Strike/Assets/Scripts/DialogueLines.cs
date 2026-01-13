using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] string[] timelineTextLines;
    [SerializeField] TMP_Text dialogueText;
    
    private int _currentLine = 0;
    
    public void NextDialogueLine()
    {
        _currentLine += 1;
        
        dialogueText.text = timelineTextLines[_currentLine];
    }
}