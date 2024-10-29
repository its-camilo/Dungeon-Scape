using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private Scene scene;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("AudioManager is null");
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
        PlaySoundtrack();
    }

    public AudioSource soundtrack;
    public AudioClip menuSelection;
    public AudioClip[] playerSounds;
    public AudioClip[] enemySounds;

    public void PlaySoundtrack()
    {
        soundtrack.Play();
    }
    
    public void PlayMenuSelection()
    {
        AudioSource.PlayClipAtPoint(menuSelection, Camera.main.transform.position);
    }
    
    public void PlayPlayerSound(int index)
    {
        if (index >= 0 && index < playerSounds.Length)
        {
            AudioSource.PlayClipAtPoint(playerSounds[index], Camera.main.transform.position);
        }
        else
        {
            Debug.LogError("Invalid sound index");
        }
    }
    
    public void PlayEnemySound(int index)
    {
        if (index >= 0 && index < enemySounds.Length)
        {
            AudioSource.PlayClipAtPoint(enemySounds[index], Camera.main.transform.position);
        }
        else
        {
            Debug.LogError("Invalid sound index");
        }
    }
}