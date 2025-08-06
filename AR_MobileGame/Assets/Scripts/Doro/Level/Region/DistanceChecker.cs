using UnityEngine;
using UnityEngine.Events;

public class DistanceChecker : MonoBehaviour
{
    public int CurrentSteps = 0;
    
    public UnityEvent OnStepTaken;
    public UnityEvent OnStepGoalReached;
    
    [SerializeField] private RegionManager _regionManager;
    [SerializeField] private bool _stepGoalReached = false;
    
    public void AddStep(int amount = 1)
    {
        if (_stepGoalReached) return;
        
        CurrentSteps += amount;
        OnStepTaken.Invoke();

        var region = _regionManager.CurrentRegion;
        if (region != null && CurrentSteps >= region.RequiredSteps)
        {
            _stepGoalReached = true;
            Debug.Log("Step goal reached!");

            OnStepGoalReached?.Invoke();
        }
    }

    //get steps from step counter-> transfer to current steps
    
    public void ResetSteps()
    {
        CurrentSteps = 0;
        _stepGoalReached = false;
    }
}
