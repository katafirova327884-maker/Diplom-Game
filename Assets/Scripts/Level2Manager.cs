using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Manager : MonoBehaviour, ILevel
{
    public static Level2Manager Instance;
    public List<CodeTask> tasks;
    public Door door;
    //private int currentTaskId;
    public int solvedTasks = 0;
    public int totalTasks = 5;

    private int currentTaskId = -1;
    private HashSet<int> solvedTaskIds = new HashSet<int>();


    void Awake()
    {
        Instance = this;
    }


    public void OpenTask(int taskId)
    {
        currentTaskId = taskId;
        GameManager.Instance.ActivateLevel2();
        UIManager.Instance.SetActiveLevel(this);
        CodeTask task = tasks[taskId];
        UIManager.Instance.ShowTask(task.brokenCode);
    }

    public void Submit(string answer)
    {
        if (solvedTaskIds.Contains(currentTaskId))
        {
            UIManager.Instance.ShowResult(new LevelResult(false, "Это задание уже решено"));
            return;
        }
        
        CodeTask task = tasks[currentTaskId];
        if (answer.Trim() == task.correctAnswer)
        {
            solvedTaskIds.Add(currentTaskId);
            solvedTasks++;
            UIManager.Instance.ShowResult(new LevelResult(true, "Код исправлен!"));
            Debug.Log("Решено задач Level2: " + solvedTasks);
            Invoke(nameof(CloseTask), 1f);
            if (solvedTasks == totalTasks)
            {
                door.Open();
                GameManager.Instance.CompleteLevel2();
            }
        }
        else 
        { 
            UIManager.Instance.ShowResult(new LevelResult(false, "Ошибка в коде. Попробуйте ещё раз"));
        }
        UIHintManager.Instance.SetLevelHint(2, solvedTasks, totalTasks);
    }

    void CloseTask()
    {
        UIManager.Instance.HideTask();
    }

}
