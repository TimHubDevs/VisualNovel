using System;
using UnityEngine;

public class Act1 : Act
{
    public override void StartAct(Action endCallback)
    {
        base.StartAct(endCallback);
        StepZero();
    }

    protected override void NextStep()
    {
        switch (currentStep)
        {
            case 1:
                StepOne();
                break;
            case 2:
                StepTwo();
                break;
            case 3:
                StepThree();
                break;
            case 4:
                StepFour();
                break;
            case 5: 
                StepFive(); 
                break;
            case 6:
                StepSix();
                break;
            case 7:
                StepSeven();
                break;
            case 8:
                StepEight();
                break;
            case 11:
                StepEleven();
                break;
            case 12:
                StepTwelve();
                break;
            case 13:
                StepThirteen();
                break;
            case 14:
                StepFourteen();
                break;
            case 15:
                StepFifteen();
                break;
            case 16:
                StepSixteen();
                break;
        }
    }

    private void StepZero()
    {
        if (settings.mainThemeSource.clip == _actMusic)
        {
            settings.mainThemeSource.UnPause();
        }
        else
        {
            settings.mainThemeSource.clip = _actMusic;
            settings.mainThemeSource.Play();
        }
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        settings.soundThemeSource.clip = _actSound[0];
        settings.soundThemeSource.Play();
        _currentMessage = _startMessage;
        SetCharacterSprite(_currentMessage.character);
        characterName.text = "Рятувальник ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 0");
        });
        StartCoroutine(_currentCoroutine);
        isCanTap = true;
    }

    private void StepOne()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Ви ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 1");
        });
        StartCoroutine(_currentCoroutine);
    }

    private void StepTwo()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Рятувальник ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 2");
        });
        StartCoroutine(_currentCoroutine);
    }

    private void StepThree()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0]; 
        HideCharacter();
        characterName.text = "??? ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 3");
        });
        StartCoroutine(_currentCoroutine);
    }

    private void StepFour()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0]; 
        SetCharacterSprite(_currentMessage.character);
        characterName.text = "Ви ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 4");
        });
        StartCoroutine(_currentCoroutine);
    }

    private void StepFive()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Надія ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 5");
        });
        StartCoroutine(_currentCoroutine);
    }

    private void StepSix()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Ви ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 6");
        });
        StartCoroutine(_currentCoroutine);
    }

    private void StepSeven()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Надія ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 7");
        });
        StartCoroutine(_currentCoroutine);
    }

    private void StepEight()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        var message1 = _currentMessage.nextMessage[0].text;
        var message2 = _currentMessage.nextMessage[1].text;
        var message3 = _currentMessage.nextMessage[2].text;
        var point1 = _currentMessage.nextMessage[0].relationPoint;
        var point2 = _currentMessage.nextMessage[1].relationPoint;
        var point3 = _currentMessage.nextMessage[2].relationPoint;
        characterName.text = "Ви ";
        SetChooseButton(message1, point1, message2, point2, message3, point3, nextMessage =>
        {
            _currentMessage = nextMessage;
            currentStep = _currentMessage.id;
            OnButtonClick();
        });
    }

    private void StepEleven()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Надія ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep = _currentMessage.nextMessage[0].id;
            Debug.Log("End Text 11");
        });
        StartCoroutine(_currentCoroutine);
    }

    private void StepTwelve()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Надія ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            Debug.Log("End Text 12");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepThirteen()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Надія ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep = _currentMessage.nextMessage[0].id;
            Debug.Log("End Text 13");
        });
        StartCoroutine(_currentCoroutine);
    }

    private void StepFourteen()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Ви ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep = _currentMessage.nextMessage[0].id;
            Debug.Log("End Text 14");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepFifteen()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Ви ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            Debug.Log("End Text 15");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepSixteen()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Надія ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            Debug.Log("End Text 16");
        });
        StartCoroutine(_currentCoroutine);
    }
}
