using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    SettingsMenu sm;
    public Sound[] sounds;  
    public static AudioManagement instance;

    public AudioMixerGroup volumeMixer;

    // Start is called before the first frame update
    void Awake()
    {

        DontDestroyOnLoad(gameObject);

        if (instance == null)
            instance = this;    
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

             s.source.outputAudioMixerGroup = volumeMixer;
        }
       

    }

    void Start()
    {
        Play("Theme");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found");
            return;
        }
            
        if(PauseMenu.GameIsPaused)
        {
            s.source.pitch *= 0f;
            s.source.volume *= 0f;
            s.source.loop = false;
        }
        
        s.source.Play();

    }

    public void Stop (string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }



    /***
    Plays the clip.
    AudioSource.PlayOneShot does not cancel clips that are already being played by AudioSource.PlayOneShot and AudioSource.Play.
    ***/
    public void PlayOneShot(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.PlayOneShot(s.clip);
    }
}
