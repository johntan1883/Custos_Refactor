using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToller : MonoBehaviour
{
    [SerializeField] private BlindBoy blindBoy;
    [SerializeField] private float minTime = 5f;
    [SerializeField] private float maxTime = 10f;

    private AudioClip bellSFX;

    private void Start()
    {
        bellSFX = GameAssets.Instance.TollerBellSoundClip;
        StartCoroutine(PlaySoundAtRandomIntervals());
    }

    IEnumerator PlaySoundAtRandomIntervals()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            PlaySound();
            NotifyBlindBoy();
            Debug.Log($"Play sound after {waitTime} seconds");
        }
    }

    private void PlaySound()
    {
        SoundFXManager.Instance.PlaySoundFXClip(bellSFX, transform, 1f);
    }

    private void NotifyBlindBoy()
    {
        if (blindBoy != null)
        {
            blindBoy.ReactToBellSFX();
        }
    }

}
