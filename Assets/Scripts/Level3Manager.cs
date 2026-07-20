using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level3Manager : MonoBehaviour
{
    public static Level3Manager Instance;
    public GameObject panel;
    public TMP_InputField codeInput;
    public TextMeshProUGUI resultText;
    public TrafficLightController trafficLight;
    private List <string> executedCommands = new List<string>();
    public Button checkButton;
    public Button submitButton;

    void Awake()
    {
        Instance = this;
    }

    public void OpenPanel()
    {
        Debug.Log("Открыт Level3Panel");
        panel.SetActive(true);
        FindObjectOfType<PlayerMovement>().canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

   public void closePanel()
    {
        Debug.Log("Закрыт Level3Panel");
        panel.SetActive(false);
        FindObjectOfType<PlayerMovement>().canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void CheckProgram()
    {
        Debug.Log("Проверка программы");
        StopAllCoroutines();
        StartCoroutine(RunProgram());
    }

    private LevelResult CheckAnswer(List<string> executedCommands)
    {
        string[] correct = { "red", "yellow", "green" };
        if (executedCommands.Count == 0) { return new LevelResult(false, "Сначала проверь"); }
        if (executedCommands.Count != correct.Length) { return new LevelResult(false, "Неверная длина программы"); }
        for (int i = 0; i < correct.Length; i++)
        {
            if (executedCommands[i] != correct[i]) { return new LevelResult(false, "Ошибка в последовательности"); }
        }
        return new LevelResult(true, "Уровень пройден!");
    }

    IEnumerator RunProgram()
    {
        executedCommands.Clear();
        string[] lines = codeInput.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        foreach (string raw in lines)
        {
            string line = raw.Trim();
            Debug.Log("Команда: " + line);
            if (line == "red")
            {
                executedCommands.Add("red");
                trafficLight.Red();
            }
            else if (line == "yellow")
            {
                executedCommands.Add("yellow");
                trafficLight.Yellow();
            }
            else if (line == "green")
            {
                executedCommands.Add("green");
                trafficLight.Green();
            }
            else if (line == "wait")
            {
                yield return new WaitForSecondsRealtime(1f);
            }
        }
    }

    public void SubmitProgram()
    {
        Debug.Log("SUBMIT НАЖАТ");

        if (UIManager.Instance == null)
        {
            Debug.LogError("UIManager.Instance = NULL!");
            return;
        }
        LevelResult result = CheckProgram(executedCommands);
        ShowResult(result);
    }

    private LevelResult CheckProgram(List<string> executedCommands)
    {
        string[] correct = { "red", "yellow", "green" };
        if (executedCommands.Count == 0) { return new LevelResult(false, "Сначала проверь"); }
        if (executedCommands.Count != correct.Length) { return new LevelResult(false, "Неверная длина программы"); }
        for (int i = 0; i < correct.Length; i++)
        {
            if (executedCommands[i] != correct[i]) { return new LevelResult(false, "Ошибка в последовательности"); }
        }
        return new LevelResult(true, "Уровень пройден!");
    }

   public void ShowResult(LevelResult result)
    {
        resultText.text = result.message;
        if (result.success) { resultText.color = Color.green; }
        else { resultText.color = Color.red; }
    }

    void Update()
    {
        //if (panel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        //{
           // closePanel();
        //}
    }

    void Start()
    {
        Debug.Log("START LEVEL3");
        Debug.Log("checkButton = " + checkButton);
        checkButton.onClick.AddListener(CheckProgram);
        Debug.Log("submitButton = " + submitButton);
        submitButton.onClick.AddListener(SubmitProgram);
    }
}
