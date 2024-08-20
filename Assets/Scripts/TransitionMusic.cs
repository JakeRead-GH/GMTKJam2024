using UnityEngine.Audio;
using UnityEngine;

public class TransitionMusic : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void OnTriggerEnter(Collider other)
    {
        bool isAPlayer = other.gameObject.CompareTag("Player");
        if (isAPlayer)
        {
            ChangeSong();
        }
        else
        {
            EndSong();
        }
    }
    private void ChangeSong()
    {
        audioMixer.SetFloat("LvlOneMusicVolume", Mathf.Lerp(0, 1, 3));
    }
    private void EndSong()
    {
        audioMixer.SetFloat("LvlOneMusicVolume", Mathf.Lerp(1, 0, 3));
    }
}
