using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip sfxClip;   
    public AudioSource audioSource;
    private float countdown = 2.0f;

    void Start()
    {
        audioSource.PlayOneShot(sfxClip);
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            audioSource.PlayOneShot(sfxClip);
            countdown = 2.0f;
        }
    }
}
