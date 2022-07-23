using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullScreenToggle;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Text settingsText;

    private Resolution[] _resolutions;
    
    public void Awake()
    {
        settingsText.text = $" Awake, ";
        // settingsPanel.SetActive(true);
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        _resolutions = Screen.resolutions;
        settingsText.text += $" _resolutions {_resolutions.Length}, ";
        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + "x" + _resolutions[i].height + " " + _resolutions[i].refreshRate + "Hz";
            options.Add(option);
            settingsText.text += $" option {i} {option}, ";
        }
        
        resolutionDropdown.AddOptions(options);
        settingsText.text += $" AddOptions {options.Count}, ";
        resolutionDropdown.RefreshShownValue();
        LoadSettings();
        SaveSettings();
#if UNITY_WEBGL
        fullScreenToggle.gameObject.SetActive(false);
#endif
        // settingsPanel.SetActive(false);
    }
    
    public void SetFullscreen()
    {
        settingsText.text += $" SetFullscreen {fullScreenToggle.isOn}, ";
        Screen.fullScreen = fullScreenToggle.isOn ;
        SaveSettings();
    }

    public void SetResolution()
    {
        Resolution resolution = _resolutions[resolutionDropdown.value];
        settingsText.text += $" SetResolution {resolution.width}*{resolution.height}, ";
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
        settingsText.text += $" LoadSettings, ";
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
        settingsText.text += $" LoadResolutionSetting {PlayerPrefs.GetInt("ResolutionPreference")}, ";
        return PlayerPrefs.GetInt("ResolutionPreference");
    }
    
    private bool LoadFullScreenSetting()
    {
        if (PlayerPrefs.HasKey("FullscreenPreference") == false)
        {
            PlayerPrefs.SetInt("FullscreenPreference", 0);
        }
        settingsText.text += $" LoadFullScreenSetting {PlayerPrefs.GetInt("FullscreenPreference") != 0}, ";
        return PlayerPrefs.GetInt("FullscreenPreference") != 0;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
