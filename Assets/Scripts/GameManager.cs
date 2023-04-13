using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<AudioClip> backgroundMusicList;
    private int currentTrackIndex;
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        // Load all AudioClips from Resources folder
        AudioClip[] allAudioClips = Resources.LoadAll<AudioClip>("Audio");
        // Add all AudioClips to backgroundMusicList
        backgroundMusicList.AddRange(allAudioClips);
    }

    void OnEnable()
    {
        // Register the OnSceneLoaded method to the SceneManager.sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unregister the OnSceneLoaded method from the SceneManager.sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find all AudioManager objects in the scene
        AudioManager[] audioManagers = FindObjectsOfType<AudioManager>();

        // Add the AudioClip from each AudioManager to the backgroundMusicList
        foreach (AudioManager audioManager in audioManagers)
        {
            backgroundMusicList.Add(audioManager.backgroundMusic);
        }
    }

    void Update()
    {
        // Check if current AudioClip has finished playing
        if (!audioSource.isPlaying)
        {
            // Move to the next AudioClip in the list
            currentTrackIndex = (currentTrackIndex + 1) % backgroundMusicList.Count;
            // Set the AudioSource clip to the next AudioClip
            audioSource.clip = backgroundMusicList[currentTrackIndex];
            // Play the next AudioClip
            audioSource.Play();
        }
    }
}
