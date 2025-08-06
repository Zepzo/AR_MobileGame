using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepDisplay : MonoBehaviour
{
    public AndroidStepCounter stepCounter;
    public TMPro.TextMeshProUGUI stepText;

    void Start()
    {
        stepCounter = gameObject.AddComponent<AndroidStepCounter>();
    }

    void Update()
    {
        stepText.text = $"Steps: {stepCounter.GetStepCount()}";
    }
}

