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
            startActNum++;
            if (_acts.Count <= startActNum)
            {
                //PlayMenuMusic
                return;
            }
            StartAct(startActNum);
        });
    }

    public void LoadPlay()
    {
        // load and play act in save system
        StartAct(2);
    }
    
    public void HideAct()
    {
        // set act active false
    }
}
