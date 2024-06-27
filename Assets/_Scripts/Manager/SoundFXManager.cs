using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySoundFXClip (AudioClip audioClip, Transform spawnTransform, float voulume)
    {
        //Spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //Assign the audioClip
        audioSource.clip = audioClip;

        //Assign volume
        audioSource.volume = voulume;

        //Play sound
        audioSource.Play();

        //Get the length of the soundFx clip
        float clipLength = audioSource.clip.length;

        //Destroy the clip after it's done playing
        Destroy(audioSource.gameObject, clipLength );
    }
}
