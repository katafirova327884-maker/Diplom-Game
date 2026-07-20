using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TheoryManager : MonoBehaviour
{
    public static TheoryManager Instance;
    public GameObject theoryPanel;
    public TextMeshProUGUI theoryText;
    private bool isOpen = false;
    private List<string> theoryPages = new List<string>();
    private int currentPage = 0;

    public bool IsOpen()
    {
        return isOpen;
    }

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Cursor.visible && !isOpen)
        {
            return;
        }
        if (isOpen)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                NextPage();
            }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                PrevPage();
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (isOpen) 
            { 
                CloseTheory(); 
            }
            else 
            { 
                OpenTheory(); 
            }
        }
    }

    void OpenTheory()
    {
        int level = GameManager.Instance.currentLevel;
        theoryPanel.SetActive(true);
        isOpen = true;

        theoryPages = BuildTheoryPages(level);
        currentPage = 0; 
        ShowCurrentPage();

        FindObjectOfType<PlayerMovement>().canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ShowCurrentPage()
    {
        theoryText.text =
            theoryPages[currentPage] +
            $"\n\nСтраница {currentPage + 1}/{theoryPages.Count}" +
            "\n <- Предыдущая | Следующая ->";
    }

    void NextPage()
    {
        if (currentPage < theoryPages.Count - 1)
        {
            currentPage++;
            ShowCurrentPage();
        }
    }

    void PrevPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            ShowCurrentPage();
        }
    }

    void CloseTheory()
    {
        theoryPanel.SetActive(false);
        isOpen = false;
        FindObjectOfType<PlayerMovement>().canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

List<string> BuildTheoryPages(int level)
    {
        List<string> pages = new List<string>();

        if (level >= 1)
        {
            pages.Add("LEVEL 1 - ЛОГИЧЕСКИЕ ОПЕРАЦИИ\n\n" +
            "Логические выражения позволяют сравнивать значения и получать результат:\n" +
            "1 - истина (True)\n" +
            "0 - ложь (False)\n\n" +
            "Операторы сравнения:\n" +
            ">  больше\n" +
            "<  меньше\n" +
            "== равно\n" +
            "!= не равно\n\n" +
            "Логические операторы:\n" +
            "&& (AND) - оба условия должны быть истинны\n" +
            "|| (OR) - хотя бы одно условие истинно\n" +
            "!  (NOT) - меняет значение на противоположное\n\n" +
            "Пример:\n" +
            "(3 > 1) && (8 / 2 == 4)\n" +
            "1 && 1 = 1\n");
        }
        if (level >= 2)
        {
            pages.Add("LEVEL 2 - ПОИСК ОШИБОК В КОДЕ\n\n" +
            "Программа должна соответствовать правилам языка.\n" +
            "Даже небольшая ошибка может помешать её выполнению.\n\n" +
            "Частые ошибки:\n\n" +
            "1. Пропущенная точка с запятой\n" +
            "int a = 10\n" +
            "Правильно: int a = 10;\n\n" +
            "2. Ошибка в ключевом слове\n" +
            "sting name = \"Alex\";\n" +
            "Правильно: string name = \"Alex\";\n\n" +
            "3. Отсутствие скобок\n" +
            "if x > 3\n" +
            "Правильно: if (x > 3)\n\n" +
            "4. Использование = вместо ==\n" +
            "if (x = 5)\n" +
            "Правильно: if (x == 5)\n" +
            "\n5. Отсутствие кавычек\n" +
            "Debug.Log(Hello);\n" +
            "Правильно: Debug.Log(\"Hello\");\n");
        }
        if (level >= 3)
        {
            pages.Add("LEVEL 3 - ИНТЕРПРЕТАЦИЯ КОМАНД\n\n" +
            "Каждая строка - отдельная команда.\n" +
            "Команды выполняются сверху вниз.\n\n" +

            "red - включить красный свет\n" +
            "yellow - включить жёлтый свет\n" +
            "green - включить зелёный свет\n" +
            "wait - задержка выполнения");
        }
        return pages;
    }
}
