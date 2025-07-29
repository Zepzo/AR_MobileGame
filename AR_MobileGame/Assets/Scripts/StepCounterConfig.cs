using UnityEngine;

[CreateAssetMenu(fileName = "StepCounterConfig", menuName = "StepCounter/Config", order = 1)]
public class StepCounterConfig : ScriptableObject
{
    [Header("Step Counter Settings")]
    [Tooltip("Average step length in meters.")]
    public float stepLength = 0.75f;

    [Header("Detection Settings")]
        [Tooltip("Acceleration threshold for detecting steps.")]
        public float threshold = 1f;
}