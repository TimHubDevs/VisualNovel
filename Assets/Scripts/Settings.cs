using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullScreenToggle;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private AudioSource musicSource, publicEffectsSourse, localEffectsSourse;
    [SerializeField] private Slider volumeSlider;

    private void Update()
    {
        SetVolume();
    }

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
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", fullScreenValue);
    }

    private void LoadSettings()
    {
        resolutionDropdown.value = LoadResolutionSetting();
        fullScreenToggle.isOn = LoadFullScreenSetting();
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

    private void SetVolume()
    {
        musicSource.volume = volumeSlider.value;
    }

    public void MusicPause()
    {
        musicSource.Pause();
    }

    public void MusicUnPause()
    {
        musicSource.UnPause();
    }

      public void SoundUnPause()
    {
        publicEffectsSourse.UnPause();
        localEffectsSourse.UnPause();

    }

    public void SoundPause()
    {
        publicEffectsSourse.Pause();
        localEffectsSourse.Pause();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

}
