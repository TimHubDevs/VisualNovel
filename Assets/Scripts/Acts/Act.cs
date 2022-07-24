using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Act : MonoBehaviour
{
    [SerializeField] public Image _background;
    [SerializeField] public Image _character;
    [SerializeField] public int _id;
    [SerializeField] public AudioClip _actMusic;
    [SerializeField] public List<AudioClip> _actSound;
    [SerializeField] public MessageModel _messageModel;
    [SerializeField] public Text characterName;
    [SerializeField] public Text characterSay;
    [SerializeField] public List<Button> buttons;
    [SerializeField] public bool canTap;
    [SerializeField] public float speedTaping;
    [SerializeField] public Settings settings;
    
    public virtual void StartAct(Action endCallback)
    {
    }

    public IEnumerator ShowText(string fullText, Action endCallback)
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            var currentText = fullText.Substring(0, i);
            characterSay.text = currentText;
            yield return new WaitForSeconds(speedTaping);
        }
        endCallback.Invoke();
    }
}
