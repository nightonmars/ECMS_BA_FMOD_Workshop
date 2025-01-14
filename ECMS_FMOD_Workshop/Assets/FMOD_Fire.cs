using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FMOD_Fire : MonoBehaviour
{
    [SerializeField] private EventReference fireReference;
    private EventInstance fireEvent;

    private void Start()
    {
        PlayTorch();
    }

    public void PlayTorch()
    {
        fireEvent = RuntimeManager.CreateInstance(fireReference);
        fireEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));
        fireEvent.start();
    }
}
