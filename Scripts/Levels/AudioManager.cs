using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0.0f, 1.0f)]
    public float volume = 0.7f;
    [Range(0.5f, 1.5f)]
    public float pitch = 1.0f;

    private AudioSource source;

    public void SetSource(AudioSource source_)
    {
        source = source_;
        source.clip = clip;
    }

    public void Play()
    {
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }

    public bool IsPlaying()
    {
        return source.isPlaying;
    }

    public void Stop()
    {
        source.Stop();
    }

    public void Loop(bool loop_)
    {
        source.loop = loop_;
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [SerializeField]
    Sound[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is more than one audio manager im the scene");
        }
    }

    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject go_ = new GameObject("Sound_" + i + "_" + sounds[i].name);
            go_.transform.SetParent(this.transform);
            sounds[i].SetSource(go_.AddComponent<AudioSource>());
        }

        if (SceneManager.GetActiveScene().name == "Winter")
        {
            LoopSound("WinterWind", true);
            PlaySound("WinterWind");
        }

        if (SceneManager.GetActiveScene().name == "Summer" || SceneManager.GetActiveScene().name == "Spring")
        {
            LoopSound("SunnyWind", true);
            PlaySound("SunnyWind");
        }
        
        if (SceneManager.GetActiveScene().name == "Home")
        {
            LoopSound("EndMusic", true);
            PlaySound("EndMusic");
        }

    }
    
    public void PlaySound(string name_)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name_)
            {
                sounds[i].Play();
                return;
            }
        }

        Debug.LogError("Could not find sound with the name: " + name_);
    }

    public void StopSound(string name_)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name_)
            {
                sounds[i].Stop();
                return;
            }
        }

        Debug.LogError("Could not find sound with the name: " + name_);
    }

    public bool SoundIsPlaying(string name_)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name_)
            {
                if (sounds[i].IsPlaying())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        Debug.LogError("Could not find sound with the name: " + name_);

        return false;
    }

    public void LoopSound(string name_, bool loop_)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == name_)
            {
                sounds[i].Loop(loop_);
                return;
            }
        }

        Debug.LogError("Could not find sound with the name: " + name_);
    }

}
