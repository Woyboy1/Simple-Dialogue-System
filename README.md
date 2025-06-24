Simple Dialogue System
By Woyboy

Unity Version 2022.3.15f1

---

*Overview*
Simple Dialogue System is a simple system that can display dialogue in a simple manner. Simply getting the input will advance to the next line. The Manager goes through an array of strings from a separate class called Dialogue.cs, then the manager would write the dialogue lines that come next. This package is expandable if you ever want to customize it more to your liking. This would help for rapid prototyping and helps developers set up a foundation for their own dialogue system.

*Features*
***Dialogue System prefab***

- Animation
- DialogueManager.cs

***Dialogue Related scripts***
  
- Dialogue.cs
- DialogueManager.cs
- DialogueTrigger.cs
- All scripts hold comments explaining their purpose


---

*The Scripts*
***Dialogue***

A regular class that does not inherit MonoBehavior but is System.Serializable
Contains an array of strings that holds all the messages in a dialogue

***DialogueTrigger***

A simple script that contains a dialogue object that uses as reference to call the DialogueManager.Instance.StartDialogue() method

***DialogueManager***

Manager class that writes, gets input, and animates the dialogue box
Simple show and hide animation

