using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LevelResult
{
    public bool success;
    public string message;
    public LevelResult(bool success, string message)
    {
        this.success = success;
        this.message = message;
    }
}
