using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QueueScript : MonoBehaviour
{
    // this queue audioQueue holds the order of buttons pressed
    // queue will play when enter(?) is pressed
    private Queue<string> audioQueue = new Queue<string>();
    public AudioSource audioSource;

    public AudioClip violin;
    public AudioClip drum;
    
    public float volume;
    
    //public Text display; // don't need this anymore?

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

        string trackName = audioQueue.Dequeue();
        AudioClip clip = null;

        // Assign AudioClip based on the track name
        switch (trackName)
        {
            case "violin":
                clip = violin;
                break;
            case "drum":
                clip = drum;
                break;
            // Add more cases for additional tracks if needed
            default:
                //Debug.Log("Unknown track name: " + trackName);
                return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("No AudioSource component found. Please assign one.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayTracks();
        }
        
    }
}
