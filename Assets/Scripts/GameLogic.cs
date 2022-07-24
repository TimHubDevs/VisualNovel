using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private List<Act> _acts;
    [SerializeField] private Settings _settings;
    [SerializeField] private AudioClip audioClip;

    private Act _currentAct;

    private void Start()
    {
        DOTween.Init();
    }

    public void StartPlay()
    {
        StartFirstActs( 0);
    }

    private void StartFirstActs(int startActNum)
    {
        _currentAct = _acts[startActNum];
        _currentAct.gameObject.SetActive(true);
        _currentAct.StartAct(() =>
        {
            StartNextAct(startActNum+1);
        });
        PlayMusicBackground(_currentAct);
    }

    public void StartNextAct(int actNum)
    {
        _currentAct = _acts[actNum];
        _currentAct.gameObject.SetActive(true);
        _currentAct.StartAct(StopPlaySound);
        PlayMusicBackground(_currentAct);
    }
    
    public void StartNextAct(int actNum, UnityAction action)
    {
        _currentAct = _acts[actNum];
        _currentAct.gameObject.SetActive(true);
        _currentAct.StartAct(() =>
        {
            StopPlaySound();
            action.Invoke();
        });
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
    }
    
    public void HideAct()
    {
        // set act active false
    }
}
