using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QueueScript : MonoBehaviour
{
    private Queue<string> audioQueue = new Queue<string>();
    public AudioSource audioSource;

    public AudioClip violin;
    public AudioClip drum;
    public AudioClip xylophone;
    // add more here
    
    public float volume;
    
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

        // assign button audio track here
        switch (trackName)
        {
            case "violin":
                clip = violin;
                break;
            case "drum":
                clip = drum;
                break;
            case "xylophone":
                clip = xylophone;
                break;
            // Add more here
            default:
                return;
        }
        
        if (clip == null)
        {
            Debug.Log("AudioClip not assigned for track: " + trackName);
            return;
        }
        
        // TODO: embrace your flaws?
        audioSource.PlayOneShot(clip, volume);
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
