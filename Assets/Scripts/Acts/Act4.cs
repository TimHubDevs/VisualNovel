using System;
using System.Collections;
using UnityEngine;

public class Act4 : Act
{
    private int chosenStep;
    
    public override void StartAct(Action endCallback)
    {
        base.StartAct(endCallback);
        StartCoroutine(StepZero());
    }

    private IEnumerator StepZero()
    {
        settings.mainThemeSource.clip = _actMusic;
        settings.soundThemeSource.clip = _actSound[0];
        _foreground.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        AnimateImageHide(_foreground, 2);
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(2);
        settings.mainThemeSource.Play();
        
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _startMessage;
        characterName.text = "Надія ";
        SetCharacterSprite(_currentMessage.character, false);
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
            case 7:
                StepSeven();
                break;
            case 8:
                StartCoroutine(StepEight());
                break;
            case 9:
                StepNine();
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
                StartCoroutine(StepThirteen());
                break;
            case 14:
                StartCoroutine(StepFourteen());
                break;
            case 15:
                StepFifteen();
                break;
            case 16:
                StepSixteen();
                break;
            case 17:
                StartCoroutine(StepSeventeen());
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
        SetCharacterSprite(_currentMessage.character, false);
        characterName.text = "Надія ";
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
        characterName.text = "Ви ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 1");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepFour()
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
                case 4:
                    chosenStep = 13;
                    break;
                case 5:
                    chosenStep = 14;
                    break;
                case 6:
                    chosenStep = 14;
                    break;
            }
            currentStep = _currentMessage.id;
            OnButtonClick();
        });
    }
    
    private void StepSeven()
    {
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
            Debug.Log("End Text 7");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private IEnumerator StepThirteen()
    {
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        AnimateImageShow(_foreground, 0);
        settings.soundThemeSource.Play();
        BackObjectScale(_background.transform);
        yield return new WaitForSeconds(4);
        _currentMessage = _currentMessage.nextMessage[0];
        _foreground.gameObject.SetActive(false);
        SetCharacterSprite(_currentMessage.character, false);
        characterName.text = "Надія ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep = _currentMessage.nextMessage[0].id;
            Debug.Log("End Text 13");
        });
        StartCoroutine(_currentCoroutine);
        isCanTap = true;
    }
    
    private IEnumerator StepFourteen()
    {
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        AnimateImageShow(_foreground, 0);
        settings.soundThemeSource.Play();
        BackObjectScale(_background.transform);
        yield return new WaitForSeconds(2);
        _currentMessage = _currentMessage.nextMessage[0];
        SetCharacterSprite(_currentMessage.character, false);
        characterName.text = "Надія ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep = _currentMessage.nextMessage[0].id;
            Debug.Log("End Text 14");
        });
        StartCoroutine(_currentCoroutine);
        isCanTap = true;
    }
    
    private IEnumerator StepEight()
    {
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        AnimateImageHide(_character, 1);
        yield return new WaitForSeconds(1);
        settings.soundThemeSource.clip = _actSound[1];
        settings.soundThemeSource.Play();
        AnimateObjectScaleUp(_background.transform, 3);
        yield return new WaitForSeconds(3);
        _currentMessage = _currentMessage.nextMessage[0];
        SetCharacterSprite(_currentMessage.character, false);
        characterName.text = "Водійка ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep = _currentMessage.nextMessage[0].id;
            Debug.Log("End Text 8");
        });
        StartCoroutine(_currentCoroutine);
        isCanTap = true;
    }
    
    private void StepNine()
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
            Debug.Log("End Text 9");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepTen()
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
            Debug.Log("End Text 10");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepEleven()
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
            Debug.Log("End Text 11");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepTwelve()
    {
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Водійка ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep = chosenStep;
            isCanTap = true;
            Debug.Log("End Text 12");
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
            currentStep++;
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
        SetCharacterSprite(_currentMessage.character, false);
        characterName.text = "Надія ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 16");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private IEnumerator StepSeventeen()
    {
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _character.gameObject.SetActive(false);
        settings.soundThemeSource.clip = _actSound[2];
        settings.soundThemeSource.Play();
        AnimateImageShow(_foreground, 20);
        yield return new WaitForSeconds(11);
        settings.soundThemeSource.clip = _actSound[3];
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(9);
        isActEnd = true;
    }
}
