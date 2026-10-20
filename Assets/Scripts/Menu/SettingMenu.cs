using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class SettingMenu : MonoBehaviour
{
    public AudioMixer mainAudioMixer;

    public Slider mainVolumeSlider;

    public Slider sfxVolumeSlider;

    public Slider musicVolumeSlider;

    public GameObject settingPanel;
    void Start()
    {
       
        // Loads Saved Slider Values (Default to 1 = Max Volume if nothing saved
        mainVolumeSlider.value = PlayerPrefs.GetFloat("MainVolume", 1f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);

        // Make the mixer match the slider when the game starts
        OnMainVolumeChange();
        OnSFXVolumeChange();
        OnMusicVolumeChange();

        //Hide the setting menu when the game Starts
        settingPanel.SetActive(false);
    }

    void Update()
    {
        // Escape opens and closes the setting menu
        if (Keyboard.current[Key.Escape].wasPressedThisFrame)
        {
            if (settingPanel.activeSelf)
            {
                CloseSetting();
            }
            else if (GameManager.instance.gameplay.activeSelf)
            {
                //only pause with escape while the game is being played
                settingPanel.SetActive(true);
                Time.timeScale = 0;
            }

        }


    }

    public void CloseSetting()
    {
        PlayerPrefs.Save();

        if (GameManager.instance.gameplay.activeSelf)
        {
            settingPanel.SetActive(false);
            Time.timeScale = 1; 
        }
        else
        {
            GameManager.instance.DoShowMainMenu();
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
    public void OnMusicVolumeChange()
    {
        mainAudioMixer.SetFloat("MusicVolume", SliderToDecibels(musicVolumeSlider.value));
        PlayerPrefs.SetFloat("MusicVolume",musicVolumeSlider.value);

    }

    public void OnSFXVolumeChange()
    {
        mainAudioMixer.SetFloat("SFXVolume", SliderToDecibels(sfxVolumeSlider.value));
        PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
    }

    public void OnMainVolumeChange()
    {
        mainAudioMixer.SetFloat("MainVolume", SliderToDecibels(mainVolumeSlider.value));
        PlayerPrefs.SetFloat("MainVolume", mainVolumeSlider.value);


    }

    //This converts a 0-1 slider value into decibels (-80 to 0) 
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
