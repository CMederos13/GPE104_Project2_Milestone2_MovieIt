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
        Debug.Log("LOADED -> Main: " + PlayerPrefs.GetFloat("MainVolume", 1f)
           + "  SFX: " + PlayerPrefs.GetFloat("SFXVolume", 1f)
           + "  Music: " + PlayerPrefs.GetFloat("MusicVolume", 1f));

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
            settingPanel.SetActive(!settingPanel.activeSelf);

            // Pause the Game when the menu is open, resumes back when closed

            if (settingPanel.activeSelf)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            //Had to add this so it can save Volume settings to disk when the menu closes
            PlayerPrefs.Save();
        }


    }
    private void OnApplicationQuit()
    {
        Debug.Log("SAVING -> Main: " + mainVolumeSlider.value
           + "  SFX: " + sfxVolumeSlider.value
           + "  Music: " + musicVolumeSlider.value);

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
