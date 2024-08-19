using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio_Manager : MonoBehaviour
{
    [Header("Audio Sources")]
    private List<AudioSource> musicSources;

    [Header("Background Music")]
    public AudioClip[] musicLevels1_5;
    public AudioClip[] musicLevels6_10; //  Need to implement this 

    public static Audio_Manager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSources = new List<AudioSource>();

        for (int i = 0; i < musicLevels1_5.Length; i++)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = musicLevels1_5[i];
            source.loop = true;
            source.volume = (i == 0) ? 0.5f : 0.0f;
            source.Play();
            musicSources.Add(source);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log($"Starting in Scene: {SceneManager.GetActiveScene().name}");
        Debug.Log($"Currently playing song: {musicLevels1_5[0].name}");
    }

    // This is here to check when a new scene loads.
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateMusicVolume(scene.name);
        Debug.Log($"Scene loaded: {scene.name}");
    }

    // This will update music volume based on the scene name
    private void UpdateMusicVolume(string sceneName)
    {
        int level = 0;

        if (sceneName.StartsWith("Level"))
        {
            if (int.TryParse(sceneName.Substring(5), out level))
            {
                Debug.Log($"Changing song for Scene: {sceneName}");

                for (int i = 0; i < musicSources.Count; i++)
                {
                    if (i == level - 1)
                    {
                        musicSources[i].volume = 0.5f;
                        Debug.Log($"Now playing song: {musicLevels1_5[i].name}");
                    }
                    else
                    {
                        musicSources[i].volume = 0.0f;
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("Scene name does not match expected format 'LevelX'.");
        }
    }
}