using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio_Manager : MonoBehaviour
{
    [Header("Audio Sources")]
    private List<AudioSource> musicSources1_4;
    private List<AudioSource> musicSources5_8;
    private AudioSource menuMusicSource;
    private AudioSource metalMusicSource;
    private AudioSource burnedMenuMusicSource;

    [Header("Background Music")]
    public AudioClip menuMusic;
    public AudioClip metalMusic;
    public AudioClip[] musicLevels1_4;
    public AudioClip[] musicLevels5_8;
    public AudioClip burnedMenuMusic;
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

        burnedMenuMusicSource = gameObject.AddComponent<AudioSource>();
        burnedMenuMusicSource.clip = burnedMenuMusic;
        burnedMenuMusicSource.loop = true;
        burnedMenuMusicSource.volume = 0.0f;  // Start muted
        burnedMenuMusicSource.Play();

        musicSources1_4 = new List<AudioSource>();
        musicSources5_8 = new List<AudioSource>();

        menuMusicSource = gameObject.AddComponent<AudioSource>();
        menuMusicSource.clip = menuMusic;
        menuMusicSource.loop = true;
        menuMusicSource.volume = 0.6f;
        menuMusicSource.Play();

        metalMusicSource = gameObject.AddComponent<AudioSource>();
        metalMusicSource.clip = metalMusic;
        metalMusicSource.loop = true;
        metalMusicSource.volume = 0.0f;
        metalMusicSource.Play();

        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log($"Starting in Scene: {SceneManager.GetActiveScene().name}");
        UpdateMusicVolume(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateMusicVolume(scene.name);
    }

    private void UpdateMusicVolume(string sceneName)
    {
        if (sceneName == "MainMenu")
        {
            menuMusicSource.volume = 0.5f;
            foreach (var source in musicSources1_4)
            {
                source.volume = 0.0f;
            }
            foreach (var source in musicSources5_8)
            {
                source.volume = 0.0f;
            }
        }
        else if (sceneName == "BurnedMenu")
        {
            burnedMenuMusicSource.volume = 0.5f;
            menuMusicSource.volume = 0.0f;
            metalMusicSource.volume = 0.0f;
            foreach (var source in musicSources1_4)
            {
                source.volume = 0.0f;
            }
            foreach (var source in musicSources5_8)
            {
                source.volume = 0.0f;
            }
        }
        else if (sceneName.StartsWith("Level"))
        {
            int level = 0;
            if (int.TryParse(sceneName.Substring(5), out level))
            {
                Debug.Log($"Scene: {sceneName}");
                menuMusicSource.volume = 0.0f;

                if (level >= 1 && level <= 4)
                {
                    InitializeMusicSources(musicSources1_4, musicLevels1_4);

                    for (int i = 0; i < musicSources1_4.Count; i++)
                    {
                        if (i == level - 1)
                        {
                            musicSources1_4[i].volume = 0.5f;
                            Debug.Log($"Song: {musicLevels1_4[i].name}");
                        }
                        else
                        {
                            musicSources1_4[i].volume = 0.0f;
                        }
                    }

                    foreach (var source in musicSources5_8)
                    {
                        source.volume = 0.0f;
                    }
                }
                else if (level >= 5 && level <= 8)
                {
                    InitializeMusicSources(musicSources5_8, musicLevels5_8);

                    for (int i = 0; i < musicSources5_8.Count; i++)
                    {
                        if (i == level - 5)
                        {
                            musicSources5_8[i].volume = 0.5f;
                            Debug.Log($"Song: {musicLevels5_8[i].name}");
                        }
                        else
                        {
                            musicSources5_8[i].volume = 0.0f;
                        }
                    }

                    foreach (var source in musicSources1_4)
                    {
                        source.volume = 0.0f;
                    }
                }
            }
        }
    }

    private void InitializeMusicSources(List<AudioSource> musicSources, AudioClip[] musicClips)
    {
        if (musicSources.Count == 0)
        {
            for (int i = 0; i < musicClips.Length; i++)
            {
                AudioSource source = gameObject.AddComponent<AudioSource>();
                source.clip = musicClips[i];
                source.loop = true;
                source.volume = 0.0f;
                source.Play();
                musicSources.Add(source);
            }
        }
    }

    public void PlayMetalMusic()
    {
        metalMusicSource.volume = 0.5f;
        Debug.Log("METAALLLLLLLL!");
        MuteAllMusic();
    }

    private void MuteAllMusic()
    {
        if (menuMusicSource != null)
        {
            menuMusicSource.volume = 0.0f;
        }

        foreach (var source in musicSources1_4)
        {
            if (source != null && source.isPlaying)
            {
                source.volume = 0.0f;
            }
        }

        foreach (var source in musicSources5_8)
        {
            if (source != null && source.isPlaying)
            {
                source.volume = 0.0f;
            }
        }
    }
}