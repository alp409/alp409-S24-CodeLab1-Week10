using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QueueScript : MonoBehaviour
{
    // this queue audioQueue holds the order of buttons pressed
    // queue will play when timer runs out
    private Queue<string> audioQueue = new Queue<string>();

    public Text display; // can't add this to the canvas????
    
    private float timer = 0;
    private float timePerTurn = 10;

    public void AddTrack(string track)
    {
        audioQueue.Enqueue(track);
    }

    public void PlayTracks()
    {
        if (audioQueue.Count == 0)
        {
            Debug.Log("Queue Empty");
            return;
        }

        string tr = audioQueue.Dequeue();
        Debug.Log(tr);
        // play queued tracks (use DeQueue?)
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        // call PlayTracks with button press
        
    }
}
