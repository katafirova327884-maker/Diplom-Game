using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int currentLevel = 1;

    public Level1Manager level1;
    public Level2Manager level2;

    public bool level2Unlocked = false;
    public bool level3Unlocked = false;
    public bool level4Unlocked = false;
    
    void Awake()
    {
        Instance = this;
    }

    public void CompleteLevel1()
    {
        level2Unlocked=true;
        currentLevel = 2;
        Debug.Log("Уровень 1 завершён. Открыт уровень 2");
    }

    public void CompleteLevel2()
    {
        level3Unlocked = true;
        currentLevel = 3;
        Debug.Log("Уровень 2 завершён. Открыт уровень 2");
    }

    public void CompleteLevel3()
    {
    }

    public void ActivateLevel2()
    {
        level1.enabled = false;
        level2.enabled = true;
    }
}
