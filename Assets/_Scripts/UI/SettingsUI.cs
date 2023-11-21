using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio; 
using System.Collections.Generic;
using TMPro;


public class SettingsUI : MonoBehaviour
{
    [Header("Graphics Settings")]
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    [Header("Audio Settings")]
    public AudioMixer audioMixer; 
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    [Header("Gameplay Settings")]
    public Toggle invertYToggle;

    [Header("Buttons")]
    public Button applyButton;
    public Button cancelButton;

    private Resolution[] resolutions;

    private void Start()
    {
        LoadAvailableResolutions();
        LoadCurrentSettings();
    }

    private void LoadAvailableResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("soundVolume", volume);
    }

    public void SetInvertY(bool isInverted)
    {
    }

    public void ApplySettings()
    {
        PlayerPrefs.SetInt("Resolution", resolutionDropdown.value);
        PlayerPrefs.SetInt("Fullscreen", BoolToInt(fullscreenToggle.isOn));
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);

        PlayerPrefs.Save();
    }

    public void CancelChanges()
    {
        LoadCurrentSettings();
    }

    private void LoadCurrentSettings()
    {
        SetResolution(PlayerPrefs.GetInt("Resolution"));
        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution");

        SetFullscreen(IntToBool(PlayerPrefs.GetInt("Fullscreen")));
        fullscreenToggle.isOn = IntToBool(PlayerPrefs.GetInt("Fullscreen"));

        SetMasterVolume(PlayerPrefs.GetFloat("MasterVolume"));
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");

        SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        SetSFXVolume(PlayerPrefs.GetFloat("SFXVolume"));
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    private int BoolToInt(bool toConvert)
    {
        if(toConvert)
            return 1;

        return 0;
    }

    private bool IntToBool(int toConvert)
    {
        if(toConvert == 1)
            return true;

        return false;
    }
}
