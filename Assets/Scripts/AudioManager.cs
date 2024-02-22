using UnityEngine;

// Define an enum for sound effect names
public enum SoundEffect
{
    StartRing,
    UIClick,

    // Add more sound effect names as needed
}

[System.Serializable]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip[] soundEffects; // Array of AudioClips for sound effects
    public AudioSource soundEffectSource; // Single AudioSource for sound effects
    public AudioSource backgroundMusic; // Single AudioSource for background music

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        // Ensure we have an AudioSource attached
        if (soundEffectSource == null)
        {
            soundEffectSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlaySoundEffect(SoundEffect soundEffect)
    {
        int index = (int)soundEffect;
        if (index >= 0 && index < soundEffects.Length)
        {
            soundEffectSource.clip = soundEffects[index];
            soundEffectSource.pitch = Random.Range(0.5f, 0.9f);
            soundEffectSource.volume = 0.5f;
            soundEffectSource.Play();
        }
        else
        {
            Debug.LogWarning("Sound effect not found in AudioManager: " + soundEffect);
        }
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = 0.5f;
            backgroundMusic.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        backgroundMusic.Stop();
    }
}
