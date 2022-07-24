using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Act : MonoBehaviour
{
    [SerializeField] public Image _background;
    [SerializeField] public int _id;
    [SerializeField] public AudioClip _actMusic;
    [SerializeField] public List<AudioClip> _actSound;
    
    public virtual void StartAct(Action endCallback)
    {
    }
}
