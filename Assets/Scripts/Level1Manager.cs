using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Manager : MonoBehaviour, ILevel
{
    public Button submitButton;
    public Door door;
    public int solvedTasks = 0;
    public int totalTasks = 3;
    private string correctAnswer;
  
    private int currentTaskId = -1;
    private HashSet<int> solvedTaskIds = new HashSet<int>();

    void Start()
    {
       
    }

    public void OpenTask(int taskId, string question, string answer)
    {
        currentTaskId = taskId;
        correctAnswer = answer;
        UIManager.Instance.SetActiveLevel(this);
        UIManager.Instance.ShowTask(question);
    }

    public void Submit(string answer)
    {
        if (UIManager.Instance == null || !gameObject.activeInHierarchy)
            return;
        if (solvedTaskIds.Contains(currentTaskId)) 
        { 
            Debug.Log("Это задание уже решено");
            UIManager.Instance.ShowResult(new LevelResult(true, "Это задание уже решено. Нажмите Esc для выхода из задания"));
            return; 
        }
        
        LevelResult result = ValidateAnswer(answer);
        UIManager.Instance.ShowResult(result);

        if (!result.success) { return; }
        solvedTaskIds.Add(currentTaskId);
        solvedTasks++;
        Debug.Log("Решено задач: " + solvedTasks);
        Invoke(nameof(CloseTask), 1f);
        if (solvedTasks == totalTasks)
        {
            Debug.Log("Все задания решены");
            door.Open();
            GameManager.Instance.CompleteLevel1();
        }
        UIHintManager.Instance.SetLevelHint(1, solvedTasks, totalTasks);
    }

    void CloseTask()
    {
        UIManager.Instance.HideTask();
    }

    LevelResult ValidateAnswer(string playerAnswer)
    {
        if (playerAnswer == correctAnswer)
        {
            return new LevelResult(true, "Правильно :)");
        }
        return new LevelResult(false, "Неправильно :(");
    }
}
