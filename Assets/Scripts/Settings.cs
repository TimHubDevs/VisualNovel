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
    [SerializeField] private GameObject dashMusic;
    [SerializeField] private GameObject dashSound;
    [SerializeField] private Button SlowerButton;
    [SerializeField] private Button FasterButton;
    [SerializeField] private Text TextSpeed;
    public int coefficientTapingDelay;
    private float[] ValuesCoefficientTapingDelay = { 0.1f, 0.075f, 0.05f, 0.025f, 0.01f };
    string[] ValuesTextSpeed = { "0,25x", "0,5x", "1x", "1,5x", "2x" };

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
        PlayerPrefsSaveSystem.SetCoefficientTapingDelay(coefficientTapingDelay);
    }

    private void LoadSettings()
    {
#if !UNITY_WEBGL
        resolutionDropdown.value = PlayerPrefsSaveSystem.LoadResolutionSetting();
        fullScreenToggle.isOn = PlayerPrefsSaveSystem.LoadFullScreenSetting();
#endif
        coefficientTapingDelay = PlayerPrefsSaveSystem.LoadTapingDelay();
        mainThemeSource.mute = PlayerPrefsSaveSystem.LoadChangeMusicState();
        soundUISourсe.mute = PlayerPrefsSaveSystem.LoadChangeSoundState();
        soundThemeSource.mute = PlayerPrefsSaveSystem.LoadChangeEventMusic();
        volumeSlider.value = PlayerPrefsSaveSystem.LoadVolumeSliderSetting();
        TextSpeed.text = GetTextSpeedValue();
        dashMusic.SetActive(mainThemeSource.mute);
        dashSound.SetActive(soundUISourсe.mute);
        volumeSlider.gameObject.SetActive(!mainThemeSource.mute || !soundUISourсe.mute);
#if !UNITY_WEBGL
        resolutionDropdown.onValueChanged.AddListener(arg =>
        {
            SetResolution();
        });
        fullScreenToggle.onValueChanged.AddListener(arg =>
        {
            SetFullscreen();
        });
#endif
        volumeSlider.onValueChanged.AddListener(arg =>
        {
            SetVolume();
        });
    }

    public void SetVolume()
    {
        mainThemeSource.volume = volumeSlider.value - 0.1f;
        soundThemeSource.volume = volumeSlider.value - 0.2f;
        soundUISourсe.volume = volumeSlider.value;
        SaveSettings();
    }

    public void AddCoefficientTapingDelay()
    {
        coefficientTapingDelay = coefficientTapingDelay + 1;
        MaxMinValueCoefficientTapingDelay();
        SaveSettings();
        TextSpeed.text = GetTextSpeedValue();
    }

    public void PutAwayCoefficientTapingDelay()
    {
        coefficientTapingDelay = coefficientTapingDelay - 1;
        MaxMinValueCoefficientTapingDelay();
        SaveSettings();
        TextSpeed.text = GetTextSpeedValue();
    }
    public int MaxMinValueCoefficientTapingDelay()
    {
        if(coefficientTapingDelay>4)
        {
            coefficientTapingDelay = 4;
        }
        if (coefficientTapingDelay<0)
        {
            coefficientTapingDelay = 0;
        }
        return coefficientTapingDelay;
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

    private string GetTextSpeedValue()
    {
        return ValuesTextSpeed[PlayerPrefsSaveSystem.LoadTapingDelay()];
    }

    public float ReturnValuesCoefficientTapingDelay()
    {
        return ValuesCoefficientTapingDelay[PlayerPrefsSaveSystem.LoadTapingDelay()];
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}