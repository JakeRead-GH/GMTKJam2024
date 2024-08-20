using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    public string nextSceneName;
    public float levelTransitionDelay;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    { 
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            Time.timeScale = 0f; //Freezes the game
            StartCoroutine(ResetSceneAfterDelay());
        }
    }

    private IEnumerator ResetSceneAfterDelay()
    {
        yield return new WaitForSecondsRealtime(3); // Wait in real-time
        Time.timeScale = 1f; // Unfreeze the game
        SceneManager.LoadScene(nextSceneName);
    }
}
