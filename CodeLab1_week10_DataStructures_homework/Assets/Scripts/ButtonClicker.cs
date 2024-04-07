using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicker : MonoBehaviour
{
    // reference to the QueueScript on Canvas
    public QueueScript queueScript; 
    
    private void Start()
    {
        queueScript = GameObject.FindObjectOfType<QueueScript>();
    }
    
    public void OnButtonClick(string instrument)
    {
        // assigned in the inspector
        queueScript.AddTrack(instrument);
    }
}
