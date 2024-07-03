using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class EnemyToller : MonoBehaviour
{
    [Header("Ring Bell")]
    [SerializeField] private BlindBoy blindBoy;
    [SerializeField] private float ringInterval = 5f;

    private BlindBoyInteractable bindBoyInteractable;

    private AudioClip bellSFX;

    private void Start()
    {
        bellSFX = GameAssets.Instance.TollerBellSoundClip;

        blindBoy = FindAnyObjectByType<BlindBoy>();

        bindBoyInteractable = blindBoy.GetComponent<BlindBoyInteractable>();
        StartCoroutine(PlaySoundAtRandomIntervals());
    }

    IEnumerator PlaySoundAtRandomIntervals()
    {
        while (true)
        {
            yield return new WaitForSeconds(ringInterval);
            PlaySound();

            if (!bindBoyInteractable.IsFollowing())
            {
                NotifyBlindBoy();
            }
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
            blindBoy.ReactToBellSFX(transform.position);
        }
    }

}
