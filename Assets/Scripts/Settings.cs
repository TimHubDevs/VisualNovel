using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullScreenToggle;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] public AudioSource mainThemeSource, soundThemeSource, soundUISourсe;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider speedTextSlider;
    [SerializeField] private GameObject dashMusic;
    [SerializeField] private GameObject dashSound;
    [SerializeField] private GameLogic gameLogic;
    private float coefficientTapingDelay;

    private Resolution[] _resolutions;

    public void Awake()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        _resolutions = Screen.resolutions;
        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + "x" + _resolutions[i].height + " " + _resolutions[i].refreshRate + "Hz";
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
#if UNITY_WEBGL
        int resolutionCoefficient = options.Count;
        resolutionDropdown.value = resolutionCoefficient;
#endif
        LoadSettings();
#if UNITY_WEBGL
        fullScreenToggle.gameObject.SetActive(false);
        exitButton.SetActive(false);
        resolutionDropdown.gameObject.SetActive(false);
#endif
    }


    public void SetFullscreen()
    {
        Screen.fullScreen = fullScreenToggle.isOn;
        SaveSettings();
    }

    public void SetResolution()
    {
        Resolution resolution = _resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        SaveSettings();
    }

    private void SaveSettings()
    {
        var fullScreenValue = fullScreenToggle.isOn ? 1 : 0;
        var changeMusicState = mainThemeSource.mute ? 1 : 0;
        var changeThemeSource = soundThemeSource.mute ? 1 : 0;
        var changeSoundState = soundUISourсe.mute ? 1 : 0;
        PlayerPrefsSaveSystem.SetResolutionSetting(resolutionDropdown.value);
        PlayerPrefsSaveSystem.SetFullscreenSetting(fullScreenValue);
        PlayerPrefsSaveSystem.SetMusicState(changeMusicState);
        PlayerPrefsSaveSystem.SetThemeSource(changeThemeSource);
        PlayerPrefsSaveSystem.SetSoundState(changeSoundState);
        PlayerPrefsSaveSystem.SetVolumeSliderValue(volumeSlider.value);
        PlayerPrefsSaveSystem.SetSpeedTextValue(speedTextSlider.value);
    }

    private void LoadSettings()
    {
#if !UNITY_WEBGL
        resolutionDropdown.value = PlayerPrefsSaveSystem.LoadResolutionSetting();
        fullScreenToggle.isOn = PlayerPrefsSaveSystem.LoadFullScreenSetting();
#endif
        mainThemeSource.mute = PlayerPrefsSaveSystem.LoadChangeMusicState();
        soundUISourсe.mute = PlayerPrefsSaveSystem.LoadChangeSoundState();
        soundThemeSource.mute = PlayerPrefsSaveSystem.LoadChangeEventMusic();
        volumeSlider.value = PlayerPrefsSaveSystem.LoadVolumeSliderSetting();
        speedTextSlider.value = PlayerPrefsSaveSystem.LoadSpeedTextSetting();
        dashMusic.SetActive(mainThemeSource.mute);
        dashSound.SetActive(soundUISourсe.mute);
        volumeSlider.gameObject.SetActive(!mainThemeSource.mute || !soundUISourсe.mute);
#if !UNITY_WEBGL
        resolutionDropdown.onValueChanged.AddListener(arg =>
        {
            SetResolution();
        });
        SetResolution();
        fullScreenToggle.onValueChanged.AddListener(arg =>
        {
            SetFullscreen();
        });
        SetFullscreen();
#endif
        volumeSlider.onValueChanged.AddListener(arg =>
        {
            SetVolume();
        });
        SetVolume();
        
        speedTextSlider.onValueChanged.AddListener(arg =>
        {
            SetSpeedText();
        });
        SetSpeedText();
    }

    public void SetVolume()
    {
        mainThemeSource.volume = volumeSlider.value - 0.1f;
        soundThemeSource.volume = volumeSlider.value - 0.2f;
        soundUISourсe.volume = volumeSlider.value;
        SaveSettings();
    }

    public void SetSpeedText()
    {
        float value = speedTextSlider.value;
        coefficientTapingDelay = 0.1f - value + 0.01f;
        SaveSettings();
        foreach (var act in gameLogic._acts)
        {
            act.SetTapingDelayValue(coefficientTapingDelay);
        }
    }


    public void ChangeMusicState()
    {
        if (mainThemeSource.mute)
        {
            mainThemeSource.mute = false;
            soundThemeSource.mute = false;
        }
        else
        {
            mainThemeSource.mute = true;
            soundThemeSource.mute = true;
        }

        SaveSettings();
        ChangeActiveVolumeSlider();
        dashMusic.SetActive(!dashMusic.activeInHierarchy);
    }

    public void ChangeSoundState()
    {
        if (soundUISourсe.mute)
        {
            soundUISourсe.mute = false;
        }
        else
        {
            soundUISourсe.mute = true;
        }

        SaveSettings();
        ChangeActiveVolumeSlider();
        dashSound.SetActive(!dashSound.activeInHierarchy);
    }

    private void ChangeActiveVolumeSlider()
    {
        volumeSlider.gameObject.SetActive(!soundUISourсe.mute || !mainThemeSource.mute);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void Support()
    {
        Application.OpenURL("https://www.patreon.com/timteamdev");
    }
}