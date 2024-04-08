using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class QueueScript : MonoBehaviour
{
    private Queue<string> audioQueue = new Queue<string>();
    public AudioSource audioSource;

    public AudioClip violin;
    public AudioClip drum;
    public AudioClip xylophone;
    public AudioClip saxophone;
    public AudioClip triangle;
    public AudioClip tambourine;
    public AudioClip cowbell;
    public AudioClip guitar;
    public AudioClip harp;
    // add more beautiful sounds here
    
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
            case "saxophone":
                clip = saxophone;
                break;
            case "triangle":
                clip = triangle;
                break;
            case "tambourine":
                clip = tambourine;
                break;
            case "cowbell":
                clip = cowbell;
                break;
            case "guitar":
                clip = guitar;
                break;
            case "harp":
                clip = harp;
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
        // press space to reset scene
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // press enter to play tracks
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayTracks();
        }
        
    }
}
