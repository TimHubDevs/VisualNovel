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
        LoadSettings();
        SaveSettings();
#if UNITY_WEBGL
        fullScreenToggle.gameObject.SetActive(false);
        exitButton.SetActive(false);
#endif
    }
    

    public void SetFullscreen()
    {
        Screen.fullScreen = fullScreenToggle.isOn ;
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
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", fullScreenValue);
        PlayerPrefs.SetFloat("VolumeSlider", volumeSlider.value);
        PlayerPrefs.SetInt("ChangeMusicState", changeMusicState);
        PlayerPrefs.SetInt("ChangeThemeSource", changeThemeSource);
        PlayerPrefs.SetInt("ChangeSoundState", changeSoundState);
    }

    private void LoadSettings()
    {
        resolutionDropdown.value = LoadResolutionSetting();
        fullScreenToggle.isOn = LoadFullScreenSetting();
        volumeSlider.value = LoadVolumeSliderSetting();
        mainThemeSource.mute = LoadChangeMusicState();
        soundUISourсe.mute = LoadChangeSoundState();
        soundThemeSource.mute = LoadChangeEventMusic();
        dashMusic.SetActive(mainThemeSource.mute);
        dashSound.SetActive(soundUISourсe.mute);
        volumeSlider.gameObject.SetActive(!mainThemeSource.mute || !soundUISourсe.mute);
        SetVolume();
        SetFullscreen();
        SetResolution();
    }

    private int LoadResolutionSetting()
    {
        if (PlayerPrefs.HasKey("ResolutionPreference") == false)
        {
            PlayerPrefs.SetInt("ResolutionPreference", 0);
        }
        return PlayerPrefs.GetInt("ResolutionPreference");
    }
    
    private bool LoadFullScreenSetting()
    {
        if (PlayerPrefs.HasKey("FullscreenPreference") == false)
        {
            PlayerPrefs.SetInt("FullscreenPreference", 0);
        }
        return PlayerPrefs.GetInt("FullscreenPreference") != 0;
    }

    private float LoadVolumeSliderSetting()
    {
        if (PlayerPrefs.HasKey("VolumeSlider") == false)
        {
            PlayerPrefs.SetFloat("VolumeSlider", 1);
        }
        return PlayerPrefs.GetFloat("VolumeSlider");
    }

    private bool LoadChangeMusicState()
    {
        if (PlayerPrefs.HasKey("ChangeMusicState") == false)
        {
            PlayerPrefs.SetInt("ChangeMusicState", 0);
        }
        return PlayerPrefs.GetInt("ChangeMusicState")!=0;
    }

    private bool LoadChangeEventMusic() { 
    if (PlayerPrefs.HasKey("ChangeThemeSource") == false)
        {
            PlayerPrefs.SetInt("ChangeThemeSource", 0);
        }
    return PlayerPrefs.GetInt("ChangeThemeSource")!=0;
    }

    private bool LoadChangeSoundState()
    {
        if (PlayerPrefs.HasKey("ChangeSoundState") == false)
        {
            PlayerPrefs.SetInt("ChangeSoundState", 0);
        }
        return PlayerPrefs.GetInt("ChangeSoundState")!=0;
    }

    public void SetVolume()
    {
        mainThemeSource.volume = volumeSlider.value - 0.1f;
        soundThemeSource.volume = volumeSlider.value - 0.2f;
        soundUISourсe.volume = volumeSlider.value;
        SaveSettings();
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
    }

   private void ChangeActiveVolumeSlider()
    {
        volumeSlider.gameObject.SetActive(!soundUISourсe.mute || !mainThemeSource.mute);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

}
