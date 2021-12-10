using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sound[] sounds;
   
    void Awake () {
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start() {
        Play("BackgroundMusic");
    }

    // Update is called once per frame
    public void Play(string name) {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();
    }

    // To call any sound from where that ound should be heard in the script, 
    // ad your sound to the audio manager inside the editor, then
    // simply copy this line, and replace name with the name of your sound in audioManager
    // FindObjectOfType<AudioManager>().Play("Name");
}
