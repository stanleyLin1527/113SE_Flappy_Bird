using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMananger : MonoBehaviour
{
    private AudioSource bgm;
    private bool isMute = false;

    public void setIsMute(bool isMute)
    {
        this.isMute = isMute;
    }

    public bool getIsMute()
    {
        return this.isMute;
    }

    private void Awake()
    {
        bgm = GetComponent<AudioSource>();
    }

    public void ToggleMute()
    {
        isMute = !isMute;
        bgm.mute = isMute;
    }
}
