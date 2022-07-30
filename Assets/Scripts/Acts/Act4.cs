using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Act4 : Act
{
    [SerializeField] private Image _foregroundWithText;
    private int chosenStep;
    
    public override void StartAct(Action endCallback)
    {
        base.StartAct(endCallback);
        StartCoroutine(StepZero());
    }

    private IEnumerator StepZero()
    {
        characterSay.font = fontForText[0];
        AnimateImageHide(_foregroundWithText, 0);
        settings.mainThemeSource.clip = _actMusic;
        settings.soundThemeSource.clip = _actSound[0];
        settings.soundThemeSource.Play();
        AnimateImageHide(_foreground, 14);
        yield return new WaitForSeconds(4);
        settings.soundThemeSource.clip = _actSound[1];
        settings.soundThemeSource.Play();
        AnimateObjectShaking(_background.transform,100);
        yield return new WaitForSeconds(10);
        settings.soundThemeSource.clip = _actSound[2];
        settings.soundThemeSource.Play();
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _startMessage;
        characterName.text = "Пасажири ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 0");
        });
        StartCoroutine(_currentCoroutine);
        isCanTap = true;
    }
    
    protected override void NextStep()
    {
        if (currentStep == 10 || currentStep == 11)
        {
            currentStep = chosenStep;
        }
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
                StartCoroutine(StepFive());
                break;
            case 6:
                StepSix();
                break;
            case 7:
                StepSeven();
                break;
            case 10:
                StepTen();
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
                StartCoroutine(StepFifteen());
                break;
            case 16:
                StepSixteen();
                break;
            case 17:
                StepSeventeen();
                break;
            case 18:
                StepEighteen();
                break;
            case 19:
                StartCoroutine(StepNineteen());
                break;
        }
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
        settings.soundThemeSource.Stop();
        StopObjectTween(_background.transform);
        characterName.text = "Пасажири ";
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
        characterName.text = "Водійка ";
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
        characterName.text = "Ви ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 4");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private IEnumerator StepFive()
    {
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        settings.mainThemeSource.Play();
        yield return new WaitForSeconds(1);
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Ви ";
        SetCharacterSprite(_currentMessage.character, false);
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 5");
        });
        StartCoroutine(_currentCoroutine);
        isCanTap = true;
    }

    private void StepSix()
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
            Debug.Log("End Text 6");
        });
        StartCoroutine(_currentCoroutine);
    }

    private void StepSeven()
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
            switch (_currentMessage.id)
            {
                case 7:
                    chosenStep = 10;
                    break;
                case 8:
                    chosenStep = 10;
                    break;
                case 9:
                    chosenStep = 11;
                    break;
            }
            currentStep = _currentMessage.id;
            OnButtonClick();
        });
    }

    private void StepTen()
    {
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        SetCharacterSprite(_currentMessage.character, false);
        characterName.text = "Надія ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep = _currentMessage.nextMessage[0].id;
            Debug.Log("End Text 10");
        });
        StartCoroutine(_currentCoroutine);
        isCanTap = true;
    }

    private void StepEleven()
    {
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        SetCharacterSprite(_currentMessage.character, false);
        characterName.text = "Надія ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep = _currentMessage.nextMessage[0].id;
            Debug.Log("End Text 11");
        });
        StartCoroutine(_currentCoroutine);
        isCanTap = true;
    }

    private void StepTwelve()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Ви ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep = chosenStep;
            isCanTap = true;
            Debug.Log("End Text 12");
        });
        StartCoroutine(_currentCoroutine);
    }

    private void StepThirteen()
    {
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Ви ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep = chosenStep;
            isCanTap = true;
            Debug.Log("End Text 13");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepFourteen()
    {
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Надія ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep = chosenStep;
            isCanTap = true;
            Debug.Log("End Text 14");
        });
        StartCoroutine(_currentCoroutine);
    }

    private IEnumerator StepFifteen()
    {
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        AnimateImageShow(_foregroundWithText, 1);
        yield return new WaitForSeconds(1);
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Ви ";
        characterSay.font = fontForText[1];
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 15");
        });
        StartCoroutine(_currentCoroutine);
        isCanTap = true;
    }
    
    private void StepSixteen()
    {
        AnimateImageShow(_foregroundWithText, 0);
        settings.soundThemeSource.clip = _actSound[3];
        settings.soundThemeSource.loop = true;
        settings.soundThemeSource.Play();
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Натовп ";
        characterSay.font = fontForText[0];
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 16");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepSeventeen()
    {
        AnimateImageHide(_foregroundWithText, 0);
        AnimateImageHide(_character, 0);
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Ви ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 17");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepEighteen()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Натовп ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 17");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private IEnumerator StepNineteen()
    {
        AnimateImageShow(_foreground, 0);
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        yield return new WaitForSeconds(2);
        settings.soundThemeSource.clip = _actSound[4];
        settings.soundThemeSource.loop = false;
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(9);
        settings.soundThemeSource.clip = _actSound[5];
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(5);
        isActEnd = true;
    }
}