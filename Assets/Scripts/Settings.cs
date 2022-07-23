using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullScreenToggle;
    [SerializeField] private GameObject settingsPanel;

    private Resolution[] _resolutions;
    
    public void Awake()
    {
        settingsPanel.SetActive(true);
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        _resolutions = Screen.resolutions;

        for (int i = 0; i < _resolutions.Length; i++)
        {
            if (_resolutions[i].refreshRate < 144)
            {
                return;
            }
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
        settingsPanel.SetActive(false);
    }
    
    public void SetFullscreen()
    {
        Screen.fullScreen = fullScreenToggle.isOn ;
        SaveSettings();
    }

    public void SetResolution()
    {
        Resolution resolution = _resolutions[resolutionDropdown.value + 1];
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
}
