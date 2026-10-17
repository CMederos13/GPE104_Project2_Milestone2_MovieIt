using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer mainAudioMixer;

    public Slider mainVolumeSlider;

    public Slider sfxVolumeSlider;

    public Slider musicVolumeSlider;

    void Start()
    {
        OnMainVolumeChange();
        OnSFXVolumeChange();
        OnMusicVolumeChange();

    }

    public void OnMusicVolumeChange()
    {
        mainAudioMixer.SetFloat("MusicVolume", SliderToDecibels(musicVolumeSlider.value));
    }

    public void OnSFXVolumeChange()
    {
        mainAudioMixer.SetFloat("SFXVolume", SliderToDecibels(sfxVolumeSlider.value));
    }

    public void OnMainVolumeChange()
    {
        mainAudioMixer.SetFloat("MainVolume", SliderToDecibels(mainVolumeSlider.value));

    }

    //This convers a 0-1 slider value into devibels (-80 to 0) 
    private float SliderToDecibels(float sliderValue)
    {
        if (sliderValue <= 0)
        {
            //Log10 doesn't work with 0, so use the quietest Value
            return -80;
        }
        return Mathf.Log10(sliderValue) * 20;
    }
}
