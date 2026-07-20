using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
            return;

        if (UIManager.Instance.taskPanel.activeSelf)
        {
            UIManager.Instance.HideTask();
            return;
        }

        if (Level3Manager.Instance != null && Level3Manager.Instance.panel.activeSelf)
        {
            Level3Manager.Instance.closePanel();
            return;
        }

        if (TheoryManager.Instance.IsOpen())
        {
            return;
        }


        Debug.Log("¬€’Œƒ »« »√–€");
        Application.Quit();
    }
}
