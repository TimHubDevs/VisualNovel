using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Act6 : Act
{
    [SerializeField] private Image _character1;
    [SerializeField] private Image _character2;
    private int chosenStep;
    private MessageModel chosenNextMessage;
    
    public override void StartAct(Action endCallback)
    {
        base.StartAct(endCallback);
        StartCoroutine(StepZero());
    }

    private IEnumerator StepZero()
    {
        isCanTap = false;
        _character1.gameObject.SetActive(false);
        _character2.gameObject.SetActive(false);
        AnimateImageShow(_foreground, 0);
        settings.mainThemeSource.clip = _actMusic;
        settings.soundThemeSource.clip = _actSound[0];
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(3);
        settings.mainThemeSource.Play();
        characterSay.font = fontForText[0];
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _startMessage;
        AnimateImageHide(_foreground, 0);
        characterName.text = "Дід ";
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
        if (currentStep == 10 || currentStep == 9 || currentStep == 8)
        {
            currentStep = chosenStep;
            var point = PlayerPrefsSaveSystem.LoadPlayerRelationSheepPoint();
            switch (currentStep)
            {
                case 10:
                    chosenNextMessage = point >= 1 ? _currentMessage.nextMessage[0].nextMessage[1] : _currentMessage.nextMessage[0].nextMessage[0];
                    break;
                case 9:
                    chosenNextMessage = _currentMessage.nextMessage[0].nextMessage[0];
                    break;
                case 8:
                    chosenNextMessage = point >= 1 ? _currentMessage.nextMessage[0].nextMessage[1] : _currentMessage.nextMessage[0].nextMessage[0];
                    break;
            }
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
                StepFive();
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
            case 17:
                StepSeventeen();
                break;
            case 18:
                StepEighteen();
                break;
            case 19:
                StepNineteen();
                break;
            case 20:
                StartCoroutine(StepTwenty());
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
        characterName.text = "Дід ";
        characterSay.font = fontForText[0];
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
        characterName.text = "Дід ";
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
    
    private void StepFive()
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
        SetCharacterSprite(_currentMessage.character, false);
        characterName.text = "Ви ";
        SetChooseButton(message1, point1, message2, point2, message3, point3, nextMessage =>
        {
            _currentMessage = nextMessage;
            switch (_currentMessage.id)
            {
                case 5:
                    chosenStep = 8;
                    break;
                case 6:
                    chosenStep = 9;
                    break;
                case 7:
                    chosenStep = 10;
                    break;
            }
            currentStep = _currentMessage.id;
            OnButtonClick();
        });
    }

    private void StepEight()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Ви ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            Debug.Log("End Text 8");
        });
        StartCoroutine(_currentCoroutine);
        currentStep = chosenNextMessage.id;
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
            Debug.Log("End Text 9");
        });
        StartCoroutine(_currentCoroutine);
        currentStep = chosenNextMessage.id;
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
            Debug.Log("End Text 10");
        });
        StartCoroutine(_currentCoroutine);
        currentStep = chosenNextMessage.id;
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
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Ви ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
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
        _character1.sprite = _currentMessage.character;
        _character1.gameObject.SetActive(true);
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
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
        characterName.text = "Дід ";
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
        AnimateImageHide(_character, 5);
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Ви ";
        characterSay.font = fontForText[1];
        _character2.sprite = _currentMessage.character;
        AnimateImageShow(_character2, 7);
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
        characterName.text = "Ви ";
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
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Дід ";
        characterSay.font = fontForText[0];
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
        characterName.text = "Софія ";
        characterSay.font = fontForText[0];
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 18");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepNineteen()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Дід ";
        characterSay.font = fontForText[0];
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 19");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private IEnumerator StepTwenty()
    {
        isCanTap = false;
        AnimateImageShow(_foreground, 0);
        settings.soundThemeSource.clip = _actSound[1];
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(3);
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _startMessage;
        isActEnd = true;
    }
}