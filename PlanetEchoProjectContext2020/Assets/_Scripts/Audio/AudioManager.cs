using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public Sound startingBgMusic;
    
    private AudioSource backGroundMusic;
    private List<AudioSource> audioSourcePool = new List<AudioSource>();
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } private set { instance = value; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        backGroundMusic = new GameObject("Audiosource", typeof(AudioSource)).GetComponent<AudioSource>();
        backGroundMusic.rolloffMode = AudioRolloffMode.Custom;
        backGroundMusic.transform.parent = transform;
        backGroundMusic.loop = true;
    }

    public void Play(string name, Vector3 location)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        AudioSource audioSource = GetAudioSource();

        audioSource.volume = s.volume;
        audioSource.pitch = s.pitch;
        audioSource.spatialBlend = s.spatialBlend;
        if (s.rollOffCustomCurve != null)
        {
            audioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff, s.rollOffCustomCurve);
            audioSource.maxDistance = s.maxDistance;
        }

        audioSource.transform.position = location;
        audioSource.PlayOneShot(s.clip);
    }

    public void PlayBackground(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        backGroundMusic.clip = s.clip;
    }

    private AudioSource GetAudioSource()
    {
        AudioSource audioSource = audioSourcePool.Find(x => !x.isPlaying);
        if (audioSource == null)
        {
            audioSource = new GameObject("Audiosource", typeof(AudioSource)).GetComponent<AudioSource>();
            audioSource.rolloffMode = AudioRolloffMode.Custom;
            audioSource.transform.parent = transform;
        }
        audioSourcePool.Add(audioSource);
        return audioSource;
    }
}

[System.Serializable]
public struct Sound
{

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    [Range(0f, 1f)]
    public float spatialBlend;
    [Range(0f, 50f)]
    public float maxDistance;

    public AnimationCurve rollOffCustomCurve;
}
