using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        Level1Task,
        Level2Task
    }
    public InteractionType interactionType;
    public int taskId;
    public string taskText;
    public string correctAnswer;

    public void Interact()
    {
        switch (interactionType)
        {
            case InteractionType.Level1Task:
                OpenLevel1Task();
                break;
            case InteractionType.Level2Task:
                OpenLevel2Task();
                break;
        }
    }

    void OpenLevel1Task()
    {
        Level1Manager manager = FindObjectOfType<Level1Manager>();

        if (manager != null)
        {
            manager.OpenTask(taskId, taskText, correctAnswer);
        }
    }

    void OpenLevel2Task()
    {
        Level2Manager manager = FindObjectOfType<Level2Manager>();

        if (manager != null)
        {
            manager.OpenTask(taskId);
        }
    }
}
