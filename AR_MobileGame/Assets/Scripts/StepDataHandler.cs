using UnityEngine;

public class StepDataHandler : MonoBehaviour
{
    // Singleton setup (similar to StepCounter)
    private static StepDataHandler _instance;
    public static StepDataHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<StepDataHandler>();
                if (_instance == null)
                {
                    GameObject container = new GameObject("StepDataHandler");
                    _instance = container.AddComponent<StepDataHandler>();
                }
            }
            return _instance;
        }
    }

    private const string lastRecordedDateKey = "LastRecordedDate";
    private const string dailyStepsKey = "DailySteps";
    public void SaveDailySteps(int stepCount)
    {
        PlayerPrefs.SetInt(dailyStepsKey, stepCount);
    }
    public void CheckForNewDay()
    {
        string currentDateString = System.DateTime.Now.ToString("yyyyMMdd");
        string lastRecordedDate = PlayerPrefs.GetString(lastRecordedDateKey, currentDateString);
        if (currentDateString != lastRecordedDate)
        {
            ResetDailySteps();
            PlayerPrefs.SetString(lastRecordedDateKey, currentDateString);
        }
        else
        {
            LoadDailySteps();
        }
    }
    private void ResetDailySteps()
    {
        PlayerPrefs.SetInt(dailyStepsKey, 0);
        StepCounter.Instance.ResetStepData();
        Debug.Log("New day, new steps! Counter reset.");
    }
    private void LoadDailySteps()
    {
        int stepCount = PlayerPrefs.GetInt(dailyStepsKey, 0);
        StepCounter.Instance.LoadStepData(stepCount);
        Debug.Log("Loaded steps from your last adventure.");
    }
}