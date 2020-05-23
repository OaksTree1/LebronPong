using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip Clip;
    public AudioSource source;
    public static AudioManager thisInstance = null;
    public float AudioVolume;

    // Start is called before the first frame update
    void Awake()
    {
        if(thisInstance == null)
        {
            thisInstance = this;
        }
        else if(thisInstance != this)
        {
            Object.Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    public void PlayDaMusic(AudioClip Aclip)
    {
        AudioSource.clip = Aclip;
        AudioSource.volume = AudioVolume;
        AudioSource.PlayOneShot(Clip);
    }
}
