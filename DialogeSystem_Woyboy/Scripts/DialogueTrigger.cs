using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// A simple script that calls the StartDialogue() method from the DialogueManager.cs class
/// You can add many ways of triggering this such as a box collision and so on.
/// </summary>
public class DialogueTrigger : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private Dialogue dialogue;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    // A simple way of testing this. You may remove this.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            TriggerDialogue();
        }
    }
}
