using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Android;

public class StepDisplay : MonoBehaviour
{
    private AndroidStepCounter stepCounter;
    public TextMeshProUGUI stepText;

    private bool isPermissionGranted = false;
    const string ACTIVITY_RECOGNITION = "android.permission.ACTIVITY_RECOGNITION";

    IEnumerator Start()
    {
        if (!Permission.HasUserAuthorizedPermission(ACTIVITY_RECOGNITION))
        {
            Permission.RequestUserPermission(ACTIVITY_RECOGNITION);
            yield return new WaitUntil(() =>
                Permission.HasUserAuthorizedPermission(ACTIVITY_RECOGNITION)
                || PlayerPrefs.GetInt("PermissionDeniedOnce", 0) == 1
            );
        }

        if (Permission.HasUserAuthorizedPermission(ACTIVITY_RECOGNITION))
        {
            isPermissionGranted = true;
            stepCounter = gameObject.AddComponent<AndroidStepCounter>();
        }
        else
        {
            PlayerPrefs.SetInt("PermissionDeniedOnce", 1);
            Debug.LogWarning("Activity Recognition permission not granted.");
        }
    }


    void Update()
    {
        if (isPermissionGranted && stepCounter != null)
        {
            stepText.text = $"{stepCounter.GetStepCount()}";
        }
        else
        {
            stepText.text = "Permission not granted";
        }
    }
}