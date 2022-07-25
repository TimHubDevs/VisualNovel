using UnityEngine;

public static class PlayerPrefsSaveSystem
{
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
}