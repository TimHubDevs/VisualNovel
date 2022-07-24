using System;
using System.Collections;
using UnityEngine;

public class Act1 : Act
{
    private MessageModel _currentMessage;
    private bool _textFull;
    private IEnumerator _currentCoroutine;
    private Action _endCallback;
    private string _fullCharacterSayText;
    private int currentStep = 0;
    
    
    public override void StartAct(Action endCallback)
    {
        StepZero();
        _endCallback = endCallback;
    }

    public void OnButtonClick()
    {
        if (CheckIsRoutinePlay())
        {
            StopCoroutine(_currentCoroutine);
            characterSay.text = _fullCharacterSayText;
            currentStep++;
        }
        else
        {
            NextStep();
        }
    }

    private void NextStep()
    {
        switch (currentStep)
        {
            case 1:
                //Step1
                Debug.Log("Start step 1");
                break;
        }
    }

    private bool CheckIsRoutinePlay()
    {
        return !_textFull;
    }

    private void StepZero()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        settings.soundThemeSource.clip = _actSound[0];
        settings.soundThemeSource.Play();
        _currentMessage = _messageModel;
        _character.sprite = _currentMessage.character;
        characterName.text = "Рятувальник: ";
        _fullCharacterSayText = _currentMessage.text;
        _currentCoroutine = ShowText(_fullCharacterSayText, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 1");
        });
        StartCoroutine(_currentCoroutine);
    }
}
