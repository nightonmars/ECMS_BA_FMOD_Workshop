using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class FMOD_Fires : MonoBehaviour
{
    [SerializeField] private PlayFMODSound [] playFireBasketSounds;
    [SerializeField] private PlayFMODSound [] playTorchSounds;

    private void Start()
    {
        PlayFireBasketSound();
        PlayTorch();
    }

    public void PlayFireBasketSound()
    {
        foreach (var playBasket in playFireBasketSounds)
        {
            playBasket.PlaySound();
        }
    }

    public void StopFireBasketSound()
    {
        foreach (var playBasket in playFireBasketSounds)
        {
            playBasket.StopSound();
        }
    }
    public void PlayTorch()
    {
        foreach (var playTorch in playTorchSounds)
        {
            playTorch.PlaySound();
        }
    }

    public void StopTorch()
    {
        foreach (var playTorch in playTorchSounds)
        {
            playTorch.StopSound();
        }
    }
    
}
