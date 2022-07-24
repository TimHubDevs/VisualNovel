using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private List<Act> _acts;
    [SerializeField] private AudioSource _musicAudioSource;

    private void Start()
    {
        DOTween.Init();
    }

    public void StartPlay()
    {
        StartActs(_acts, 0);
    }

    private void StartActs(List<Act> acts, int startActNum)
    {
        acts[startActNum].gameObject.SetActive(true);
        acts[startActNum].StartAct(() =>
        {
            TryStartNextAct(_acts, startActNum+1);
            acts[startActNum].gameObject.SetActive(false);
        });
        PlayMusicBackground(acts, startActNum);
    }

    private void TryStartNextAct(List<Act> acts, int startActNum)
    {
        if (acts.Count <= startActNum) return;
        acts[startActNum].gameObject.SetActive(true);
        acts[startActNum].StartAct(() =>
        {
            TryStartNextAct(_acts, startActNum+1);
            acts[startActNum].gameObject.SetActive(false);
        });
        PlayMusicBackground(acts, startActNum);
    }

    private void PlayMusicBackground(List<Act> acts, int startActNum)
    {
        if (_musicAudioSource.clip == acts[startActNum]._actMusic) return;
        _musicAudioSource.clip = acts[startActNum]._actMusic;
        _musicAudioSource.Play();
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
