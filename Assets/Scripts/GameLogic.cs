using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private List<Act> _acts;
    [SerializeField] private Settings _settings;

    private Act _currentAct;

    private void Start()
    {
        DOTween.Init();
    }

    public void StartPlay()
    {
        StartFirstAct();
    }

    private void StartFirstAct()
    {
        StartAct(0);
    }

    private void StartAct(int startActNum)
    {
        _currentAct = _acts[startActNum];
        _currentAct.gameObject.SetActive(true);
        _currentAct.StartAct(() =>
        {
            StopPlaySound();
            startActNum++;
            if (_acts.Count <= startActNum)
            {
                //PlayMenuMusic
                return;
            }
            StartNextAct(startActNum);
        });
        PlayMusicBackground(_currentAct);
    }

    private void StartNextAct(int actNum)
    {
        _currentAct = _acts[actNum];
        _currentAct.gameObject.SetActive(true);
        _currentAct.StartAct(StopPlaySound);
        PlayMusicBackground(_currentAct);
    }

    private void StopPlaySound()
    {
        _settings.soundThemeSource.clip = null;
    }

    private void PlayMusicBackground(Act act)
    {
        if (_settings.mainThemeSource.clip == act._actMusic) return;
        _settings.mainThemeSource.clip = act._actMusic;
        _settings.mainThemeSource.Play();
    }


    public void LoadPlay()
    {
        // load and play act in save system
        StartAct(1);
    }
    
    public void HideAct()
    {
        // set act active false
    }
}
