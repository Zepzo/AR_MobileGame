using UnityEngine;
using UnityEngine.Android;

/// <summary>
/// Unity bridge for accessing Android native step counter (TYPE_STEP_COUNTER).
/// For Android 10+ (API 29+), includes runtime permission request.
/// </summary>
public class AndroidStepCounter : MonoBehaviour
{
    private static AndroidJavaObject pluginInstance;
    private static bool initialized = false;
    private static bool permissionRequested = false;

    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        // Request permission on Android 10+ (API 29+)
        if (!Permission.HasUserAuthorizedPermission("android.permission.ACTIVITY_RECOGNITION"))
        {
            if (!permissionRequested)
            {
                Permission.RequestUserPermission("android.permission.ACTIVITY_RECOGNITION");
                permissionRequested = true;
            }
            return;
        }

        // Only initialize once
        if (!initialized)
        {
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

                // Replace with your actual Java plugin package/class name
                AndroidJavaClass pluginClass = new AndroidJavaClass("com.ForsbergsAR.Wanderlust.StepCounterPlugin");

                pluginInstance = pluginClass.CallStatic<AndroidJavaObject>("getInstance");
                pluginInstance.Call("start", activity);
                initialized = true;
            }
        }
#endif
    }

    /// <summary>
    /// Returns the number of steps counted since app start.
    /// </summary>
    public int GetStepCount()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (pluginInstance != null)
        {
            return pluginInstance.Call<int>("getStepCount");
        }
#endif
        return 0;
    }

    /// <summary>
    /// Optional: resets the internal counter in the Java plugin.
    /// </summary>
    public void ResetStepCounter()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (pluginInstance != null)
        {
            pluginInstance.Call("reset");
        }
#endif
    }

    void OnDestroy()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (pluginInstance != null)
        {
            pluginInstance.Call("stop");
        }
#endif
    }
}
