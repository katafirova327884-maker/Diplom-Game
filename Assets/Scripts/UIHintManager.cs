using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHintManager : MonoBehaviour
{
    public static UIHintManager Instance;
    public TextMeshProUGUI hintText;

    void Awake()
    {
        Instance = this;
    }

    public void  ShowHint(string text)
    {
        hintText.text = text;
    }

    public void SetLevelHint(int level, int solved, int total)
    {
        hintText.text = " Уровень " + level + "\n" + "Задания: " + solved + "/" + total + "\n";
    }
}
