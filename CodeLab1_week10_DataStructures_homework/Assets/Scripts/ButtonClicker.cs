using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicker : MonoBehaviour
{
    public QueueScript queueScript; // Reference to the QueueScript
    
    private void Start()
    {
        // Find the QueueScript in the scene
        queueScript = GameObject.FindObjectOfType<QueueScript>();
    }

    // Method to handle button click event
    public void OnButtonClick(string instrument)
    {
        // Add the instrument to the audioQueue in the QueueScript
        queueScript.AddTrack(instrument);
    }
}
