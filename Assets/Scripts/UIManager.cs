using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject taskPanel;
    public TextMeshProUGUI taskText;
    public TMP_InputField answerInput;
    public TMP_Text resultText;

    private ILevel activeLevel;
    public Button submitButton;

    void Awake()
    {
        Instance = this;
    }

    public void ShowTask(string question)
    {
        PlayerMovement pm = FindObjectOfType<PlayerMovement>();
        pm.canMove = false;

        taskPanel.SetActive(true);
        taskText.text = question;
        answerInput.text = "";
        resultText.text = "";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideTask()
    {
        PlayerMovement pm = FindObjectOfType<PlayerMovement>();
        pm.canMove = true;
        taskPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowResult(LevelResult result)
    {
        resultText.text = result.message;
        if (result.success) 
        { 
            resultText.color = Color.green; 
        }
        else 
        { 
            resultText.color = Color.red; 
        }
    }

    public string GetPlayerAnswer()
    {
        return answerInput.text.Trim();
    }

    public void SetActiveLevel(ILevel level)
    {
        activeLevel = level;
    }

    void Start()
    {
        submitButton.onClick.AddListener(OnSubmit);
    }

    void OnSubmit()
    {
        if (activeLevel == null) return;
        string answer = GetPlayerAnswer();
        activeLevel.Submit(answer);
    }
}
