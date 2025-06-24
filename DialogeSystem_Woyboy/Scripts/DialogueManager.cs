using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// A DialogueManager class that handles writing the dialogue, gets input
/// to moving on the next line, and completing all the lines of the 
/// Dialogue.cs class. 
/// 
/// You call the StartDialogue() method to begin your dialogue. Typically
/// called from DialogueTrigger, but really you can call this from anywhere.
/// 
/// </summary>
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("Assignables - UI")]
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Animator anim;

    [Header("Settings")]
    [SerializeField] private float typingSpeed = 0.05f;

    [Header("Input")]
    [SerializeField] private KeyCode nextLineKey = KeyCode.E;

    private bool isDialogueActive = false;
    private Dialogue currentDialogue;
    private int currentLineIndex = 0;
    private Coroutine typingCoroutine;
    private bool isTyping = false;

    private const string ShowAnimParameter = "Show";

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (isDialogueActive && Input.GetKeyDown(nextLineKey))
        {
            if (isTyping)
            {
                CompleteTyping();
            }
            else
            {
                DisplayNextLine();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        currentLineIndex = 0;
        isDialogueActive = true;
        anim.SetBool(ShowAnimParameter, true);
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (currentLineIndex < currentDialogue.DialogueLines.Length)
        {
            string line = currentDialogue.DialogueLines[currentLineIndex];
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            typingCoroutine = StartCoroutine(TypeDialogueLine(line));
            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeDialogueLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    private void CompleteTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        dialogueText.text = currentDialogue.DialogueLines[currentLineIndex - 1];
        isTyping = false;
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        anim.SetBool(ShowAnimParameter, false);
        dialogueText.text = ""; // empty
    }
}