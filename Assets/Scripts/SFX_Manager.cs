// This script takes care of playing the sound effects in the game. 
// It has a function that plays a single sound effect and a function 
// that plays multiple random sound effects (eg. steps)  from an array of sound effects.

using UnityEngine;

public class SFX_Manager : MonoBehaviour
{
    public static SFX_Manager instance;
    [SerializeField] private AudioSource SFX_Object;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Plays a single SFX
    public void PlaySFX(AudioClip audioclip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(SFX_Object, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioclip;
        audioSource.volume = volume;
        audioSource.Play();

        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
    // Plays a random SFX from an array of sound effects
    // I implemented this in the PlayerMovement.cs script in the PlayFootsteps() coroutine
    // Example of usage: SFX_Manager.instance.PlayRandomSFX(sfx_steps, transform, 0.5f);
    public void PlayRandomSFX(AudioClip[] audioclip, Transform spawnTransform, float volume)
    {
        int randomIndex = Random.Range(0, audioclip.Length);

        AudioSource audioSource = Instantiate(SFX_Object, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioclip[randomIndex];
        audioSource.volume = volume;
        audioSource.Play();

        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

}