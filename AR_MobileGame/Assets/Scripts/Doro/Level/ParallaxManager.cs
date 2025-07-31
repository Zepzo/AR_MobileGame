using UnityEngine;
using UnityEngine.Serialization;

public class ParallaxManager : MonoBehaviour
{
    public ParallaxLayer[] Layers;
    public float ScrollSpeed = 2f;
    
    void Update()//----------------- change to Event Trigger OnStep later
    {
        foreach (var layer in Layers)
            layer.Scroll(ScrollSpeed);
    }
}