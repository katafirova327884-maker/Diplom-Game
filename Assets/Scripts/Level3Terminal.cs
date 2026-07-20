using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Terminal : MonoBehaviour
{
    public void Interact()
    {
        Debug.Log("Терминал Level3 активирован");
        Level3Manager.Instance.OpenPanel();
    }
}
