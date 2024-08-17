using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip playerDeath;
    public AudioClip playerHit;
    public AudioClip levelUp;
    public AudioClip explosion;
    public AudioClip powerCollection;
    public AudioClip shooting;

    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GameObject.FindGameObjectWithTag("audioManager").GetComponent<AudioSource>();
        explosion = Resources.Load<AudioClip>("effects/explosion");
    }

    private void Update()
    {
        
    }
    public void PlayAudioClip(string clipName)
    {
        AudioClip clipToPlay = null;

        // Determine which clip to play based on the clipName
        switch (clipName)
        {
            case "playerDeath":
                clipToPlay = playerDeath;
                break;
            case "playerHit":
                if (clipToPlay == playerHit)
                    return;
                clipToPlay = playerHit;
                break;
            case "levelUp":
                clipToPlay = levelUp;
                break;
            case "explosion":
                clipToPlay = explosion;
                break;
            case "powerCollection":
                clipToPlay = powerCollection;
                break;
            case "shooting":
                clipToPlay = shooting;
                break;
            default:
                Debug.LogWarning("Audio clip not found: " + clipName);
                return;
        }

        // Play the selected audio clip
        if (clipToPlay != null)
        {
            if(clipToPlay != shooting)
                audioSource.Stop();



            audioSource.PlayOneShot(clipToPlay);
        }
    }
}
