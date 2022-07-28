using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private List<Act> _acts;
    [SerializeField] private Settings _settings;
    [SerializeField] private AudioClip _menuClip;

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
            startActNum++;
            if (_acts.Count <= startActNum)
            {
                //PlayMenuMusic
                _settings.mainThemeSource.clip = _menuClip;
                _settings.soundThemeSource.clip = null;
                _settings.mainThemeSource.Play();
                return;
            }
            StartAct(startActNum);
        });
    }

    public void LoadPlay()
    {
        // load and play act in save system
        StartAct(3);
    }
    
    public void HideAct()
    {
        // set act active false
    }
}
