using UnityEngine;

public static class PlayerPrefsSaveSystem
{
    public static int LoadGameStep()
    {
        if (PlayerPrefs.HasKey("GameStep") == false)
        {
            PlayerPrefs.SetInt("GameStep", 0);
        }
        return PlayerPrefs.GetInt("GameStep");
    }
    
    public static int LoadResolutionSetting()
    {
        if (PlayerPrefs.HasKey("ResolutionPreference") == false)
        {
            PlayerPrefs.SetInt("ResolutionPreference", 0);
        }
        return PlayerPrefs.GetInt("ResolutionPreference");
    }
    
    public static bool LoadFullScreenSetting()
    {
        if (PlayerPrefs.HasKey("FullscreenPreference") == false)
        {
            PlayerPrefs.SetInt("FullscreenPreference", 0);
        }
        return PlayerPrefs.GetInt("FullscreenPreference") != 0;
    }

    public static float LoadVolumeSliderSetting()
    {
        if (PlayerPrefs.HasKey("VolumeSlider") == false)
        {
            PlayerPrefs.SetFloat("VolumeSlider", 1);
        }

        return PlayerPrefs.GetFloat("VolumeSlider");

    }    public static float LoadSpeedTextSetting()
    {
        if (PlayerPrefs.HasKey("SpeedText") == false)
        {
            PlayerPrefs.SetFloat("SpeedText", 0.5f);
        }

        return PlayerPrefs.GetFloat("SpeedText");
    }

    public static bool LoadChangeMusicState()
    {
        if (PlayerPrefs.HasKey("SaveChangeMusicState") == false)
        {
            PlayerPrefs.SetInt("SaveChangeMusicState", 0);
        }

        return PlayerPrefs.GetInt("SaveChangeMusicState") != 0;
    }

    public static bool LoadChangeEventMusic()
    {
        if (PlayerPrefs.HasKey("SaveChangeThemeSource") == false)
        {
            PlayerPrefs.SetInt("SaveChangeThemeSource", 0);
        }

        return PlayerPrefs.GetInt("SaveChangeThemeSource") != 0;
    }

    public static bool LoadChangeSoundState()
    {
        if (PlayerPrefs.HasKey("SaveChangeSoundState") == false)
        {
            PlayerPrefs.SetInt("SaveChangeSoundState", 0);
        }

        return PlayerPrefs.GetInt("SaveChangeSoundState") != 0;
    }
    
    public static int LoadPlayerRelationSheepPoint()
    {
        if (PlayerPrefs.HasKey("PlayerPoint") == false)
        {
            PlayerPrefs.SetInt("PlayerPoint", 0);
        }
        return PlayerPrefs.GetInt("PlayerPoint");
    }

    public static void SetResolutionSetting(int resolution)
    {
        PlayerPrefs.SetInt("ResolutionPreference", resolution);
    }
    
    public static void SetFullscreenSetting(int fullscreen)
    {
        PlayerPrefs.SetInt("FullscreenPreference", fullscreen);
    }
    
    public static void SetPlayerRelationSheepPoint(int point)
    {
        PlayerPrefs.SetInt("PlayerPoint", point);
    }
    
    public static void SetVolumeSliderValue(float value)
    {
        PlayerPrefs.SetFloat("VolumeSlider", value);
    }
    public static void SetSpeedTextValue(float value)
    {
        PlayerPrefs.SetFloat("SpeedText", value);
    }
    
    public static void SetMusicState(int state)
    {
        PlayerPrefs.SetInt("SaveChangeMusicState", state);
    }
    
    public static void SetThemeSource(int state)
    {
        PlayerPrefs.SetInt("SaveChangeThemeSource", state);
    }
    
    public static void SetSoundState(int state)
    {
        PlayerPrefs.SetInt("SaveChangeSoundState", state);
    }
    
    public static void SetGameStep(int step)
    {
        PlayerPrefs.SetInt("GameStep", step);
    }
}