using System;
using System.Collections;
using UnityEngine;

public class Act2 : Act
{
    public override void StartAct(Action endCallback)
    {
        base.StartAct(endCallback);
        StartCoroutine(StepZero());
    }

    private IEnumerator StepZero()
    {
        settings.mainThemeSource.clip = _actMusic;
        settings.soundThemeSource.clip = _actSound[0];
        settings.soundThemeSource.Play();
        _foreground.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        AnimateImageHide(_foreground, 2);
        yield return new WaitForSeconds(2);
        settings.mainThemeSource.Play();
        
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _startMessage;
        characterName.text = "Ви ";
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
            case 6:
                StepSix();
                break;
            case 7:
                StepSeven();
                break;
            case 8:
                StepEight();
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
                StartCoroutine(StepTwelve());
                break;
            case 13:
                StartCoroutine(StepThirteen());
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
        SetCharacterSprite(_currentMessage.character, false);
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
    
    private void StepSix()
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
    
    private void StepEight()
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
            Debug.Log("End Text 8");
        });
        StartCoroutine(_currentCoroutine);
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
        characterName.text = "Ви ";
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
    
    private IEnumerator StepTwelve()
    {
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        _character.gameObject.SetActive(false);
        settings.soundThemeSource.clip = _actSound[1];
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(2);
        SetCharacterSprite(_currentMessage.character, true);
        //show other characters
        AnimateImageShow(_character, 2);
        yield return new WaitForSeconds(2);
        AnimateImageShow(_blur, 1);
        characterName.text = "Ви ";
        characterSay.font = fontForText[1];
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 12");
        });
        StartCoroutine(_currentCoroutine);
        isCanTap = true;
    }
    
    private IEnumerator StepThirteen()
    {
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        settings.soundThemeSource.clip = _actSound[2];
        settings.soundThemeSource.Play();
        AnimateImageShow(_foreground, 0);
        //Hide other character
        AnimateImageHide(_character, 0);
        AnimateImageHide(_blur, 0);
        yield return new WaitForSeconds(2);
        AnimateImageHide(_foreground, 4);
        yield return new WaitForSeconds(4);
        _currentMessage = _currentMessage.nextMessage[0];
        SetCharacterSprite(_currentMessage.character, true);
        AnimateImageShow(_character, 1);
        characterName.text = "Ви ";
        characterSay.font = fontForText[0];
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 13");
        });
        StartCoroutine(_currentCoroutine);
        isCanTap = true;
    }
    
    private void StepFourteen()
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
        AnimateImageHide(_character, 1);
        yield return new WaitForSeconds(1);
        AnimateImageShow(_foreground, 2);
        yield return new WaitForSeconds(2);
        isActEnd = true;
    }
}
