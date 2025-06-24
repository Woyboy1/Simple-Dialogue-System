using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple dialogue class that holds all the dialogue lines. You can
/// easily modify this if you ever want to add different elements such
/// as names for the dialogue.
/// </summary>

[System.Serializable]
public class Dialogue
{
    [SerializeField] private string[] dialogueLines;

    public string[] DialogueLines => dialogueLines;
}
