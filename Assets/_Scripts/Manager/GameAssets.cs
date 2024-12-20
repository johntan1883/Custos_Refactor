using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _instance;

    public static GameAssets Instance
    {
        get
        {
            if (_instance == null) _instance = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _instance; 
        }
    }

    public AudioClip BarkToFollowSoundClip;
    public AudioClip BarkToInteractSoundClip;
    public AudioClip TollerBellSoundClip;
    public AudioClip CrateBreakSoundClip;
    public AudioClip DoorOpenSoundClip;
    public AudioClip HorrorSoundClip;
    public AudioClip SpottedPlayerSoundClip;
}
