using UnityEngine;
using UnityEngine.UI;


public class DebugButtonTest : MonoBehaviour
{
    public GameObject button;
    void Update()
    {
        //DebugDrag();
    }
    
    public void PrintDebug()
    {
        Debug.Log("You just pressed the button: " + gameObject.name);

        // button = gameObject;
        // Debug.Log("You just pressed the button: " + button.name);
    }

    public void DebugDrag()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Touch started at: " + touch.position);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Touch has ended at: " + touch.position);
            }
        }
    }

    public void TapCount()
    {
        
    }
}
