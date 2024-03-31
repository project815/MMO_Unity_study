using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class SoundManager
{
    private AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];

    private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();
    
    public void Init()
    {
        GameObject root = GameObject.Find("@Sound");
        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
            Object.DontDestroyOnLoad(root);

            string[] soundNames = Enum.GetNames(typeof(Define.Sound));
            for(int i = 0; i < soundNames.Length - 1; i++)
            {
                GameObject go = new GameObject { name = soundNames[i] };
                _audioSources[i] = go.AddComponent<AudioSource>();

                go.transform.parent = root.transform;
            }

            _audioSources[(int)Define.Sound.Bgm].loop = true;
        }
    }
    
    public void Play( string path,Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
    {
 
        AudioClip audioClip= GetOrAddAudioClip(path);
        Play(audioClip, type, pitch);
    }
    
    public void Play( AudioClip audioClip,Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
    {
        if (audioClip == null) return;
        if (type == Define.Sound.Bgm)
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];

            if (audioSource.isPlaying)
                audioSource.Stop();
            
            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.Effect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }
    }

    AudioClip GetOrAddAudioClip(string path)
    {
        if (path.Contains("Sound/") == false)
            path = $"Sounds/{path}";
        
        AudioClip _audioClip = null;
        
        if (_audioClips.TryGetValue(path, out _audioClip) == false)
        {
            _audioClip = Managers.Resource.Load<AudioClip>(path);
            _audioClips.Add(path, _audioClip);
        }
        
        if (_audioClip == null)
        {
            Debug.Log($"AudioClip Missing! :{path}");
        }
        
        return _audioClip;
    }

    public void Clear()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        _audioClips.Clear();
    }
}
