using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTrigger : MonoBehaviour
{
    private AudioClip horrorSFX;
    private bool playedSFX;
    private void Awake()
    {
        horrorSFX = GameAssets.Instance.HorrorSoundClip;
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            if (!playedSFX)
            {
                PlayHorrorSFX();
            }
        }
    }

    private void PlayHorrorSFX()
    {
        SoundFXManager.Instance.PlaySoundFXClip(horrorSFX, transform, 1f);

        playedSFX = true;
    }
}
