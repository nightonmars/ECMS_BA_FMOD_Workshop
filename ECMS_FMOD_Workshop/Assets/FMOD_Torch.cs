using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class FMOD_Torch : MonoBehaviour
{
    [SerializeField] private EventReference torchReference;
    private EventInstance torchEvent;

    private void Start()
    {
        PlayTorch();
    }

    public void PlayTorch()
    {
        torchEvent = RuntimeManager.CreateInstance(torchReference);
        torchEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));
        torchEvent.start();
    }
}
