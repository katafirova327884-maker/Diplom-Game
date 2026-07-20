using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;

    void Start()
    {
        AllOff();
    }

    public void AllOff()
    {
        redLight.SetActive(false);
        yellowLight.SetActive(false);  
        greenLight.SetActive(false);
    }

    public void Red()
    {
        Debug.Log("Красный");
        AllOff();
        redLight.SetActive(true);
    }

    public void Yellow()
    {
        Debug.Log("Жёлтый");
        AllOff();
        yellowLight.SetActive(true);
    }

    public void Green()
    {
        Debug.Log("Зелёный");
        AllOff();
        greenLight.SetActive(true);
    }
}
