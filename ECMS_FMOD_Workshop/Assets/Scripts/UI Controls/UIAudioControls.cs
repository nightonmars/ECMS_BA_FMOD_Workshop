using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class UIAudioControls : MonoBehaviour
{
    private string masterBusString = "bus:/";
    private string sfxBusString = "bus:/SFX";
    private string musicBusString = "bus:/MUSIC";
    Bus masterBus;
    Bus sfxBus;
    Bus musicBus;
    
    void Start()
    {
        masterBus = RuntimeManager.GetBus(masterBusString);
        sfxBus = RuntimeManager.GetBus(sfxBusString);
        musicBus = RuntimeManager.GetBus(musicBusString);
    }
    
    public void AdjustMainVolume(float newVol)
    {
        // Clamp to avoid Log10(0)
        float clampedVol = Mathf.Clamp(newVol, 0.0001f, 1.0f);
        float dB = 20f * Mathf.Log10(clampedVol);
        
        masterBus.setVolume(clampedVol);
    }
    
    public void AdjustSFXVolume(float newVol)
    {
        // Clamp to avoid Log10(0)
        float clampedVol = Mathf.Clamp(newVol, 0.0001f, 1.0f);
        float dB = 20f * Mathf.Log10(clampedVol);
        
        sfxBus.setVolume(clampedVol);
    }
    
    public void AdjustMusicVolume(float newVol)
    {
        // Clamp to avoid Log10(0)
        float clampedVol = Mathf.Clamp(newVol, 0.0001f, 1.0f);
        float dB = 20f * Mathf.Log10(clampedVol);
        
        musicBus.setVolume(clampedVol);
        Debug.Log("Adjust Music Volume: " + clampedVol);
    }
   
}
