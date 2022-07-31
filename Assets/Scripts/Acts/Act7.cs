using System;
using System.Collections;
using UnityEngine;

public class Act7 : Act
{
    [SerializeField] private Sprite _backHappy;
    [SerializeField] private Sprite _backNeutral;
    [SerializeField] private Sprite _backBad;
    [SerializeField] private Sprite _finalSprite;
    private int chosenStep;
    private MessageModel chosenMessage;
    
    public override void StartAct(Action endCallback)
    {
        base.StartAct(endCallback);
        StartCoroutine(StepZero());
    }

    private IEnumerator StepZero()
    {
        isCanTap = false;
        AnimateImageShow(_foreground, 0);
        settings.mainThemeSource.clip = _actMusic;
        settings.soundThemeSource.clip = _actSound[0];
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(3);
        settings.mainThemeSource.Play();
        AnimateImageHide(_foreground, 0);
        characterSay.font = fontForText[1];
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _startMessage;
        AnimateImageHide(_foreground, 0);
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
        if (currentStep == 4)
        {
            currentStep = chosenStep;
            _currentMessage = chosenMessage;
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
                StepTwenty();
                break;
            case 21:
                StepTwentyOne();
                break;
            case 22:
                StepTwentyTwo();
                break;
            case 23:
                StepTwentyThree();
                break;
            case 24:
                StepTwentyFour();
                break;
            case 25:
                StepTwentyFive();
                break;
            case 26:
                StepTwentySix();
                break;
            case 27:
                StepTwentySeven();
                break;
            case 28:
                StartCoroutine(StepTwentyEight());
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
        characterName.text = "Ви ";
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
        characterName.text = "Надія ";
        characterSay.font = fontForText[0];
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            Debug.Log("End Text 3");
        });
        StartCoroutine(_currentCoroutine);
        var points = PlayerPrefsSaveSystem.LoadPlayerRelationSheepPoint();
        if (points > 9)
        {
            chosenStep = _currentMessage.nextMessage[0].id;
            chosenMessage = _currentMessage.nextMessage[0];
        }else if (points > 1 && points < 9)
        {
            chosenStep = _currentMessage.nextMessage[1].id;
            chosenMessage = _currentMessage.nextMessage[1];
        }else if (points <= 1)
        {
            chosenStep = _currentMessage.nextMessage[2].id;
            chosenMessage = _currentMessage.nextMessage[2];
        }
    }
    
    private void StepFour()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        settings.mainThemeSource.clip = _actSound[1];
        settings.mainThemeSource.Play();
        characterName.text = "Надія ";
        SetCharacterSprite(_currentMessage.character, false);
        _background.sprite = _backHappy;
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
        characterName.text = "Ви ";
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
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Надія ";
        SetCharacterSprite(_currentMessage.character, false);
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
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Надія ";
        SetCharacterSprite(_currentMessage.character, false);
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
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
        characterName.text = "Надія ";
        SetCharacterSprite(_currentMessage.character, false);
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
        SetChooseButton(_currentMessage.text, model =>
        {
            currentStep = _currentMessage.id;
            OnButtonClick();
        });
    }

    private void StepEleven()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        settings.mainThemeSource.clip = _actSound[2];
        settings.mainThemeSource.Play();
        _background.sprite = _backNeutral;
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
        characterName.text = "Надія ";
        SetCharacterSprite(_currentMessage.character, false);
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
        characterName.text = "Ви ";
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
        characterName.text = "Надія ";
        SetCharacterSprite(_currentMessage.character, false);
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
        characterName.text = "Надія ";
        SetCharacterSprite(_currentMessage.character, false);
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
        characterName.text = "Надія ";
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
        characterName.text = "Надія ";
        SetCharacterSprite(_currentMessage.character, false);
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
        characterName.text = "Ви ";
        SetChooseButton(_currentMessage.text, model =>
        {
            currentStep = _currentMessage.id;
            OnButtonClick();
        });
    }
    
    private void StepNineteen()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        settings.mainThemeSource.clip = _actSound[3];
        settings.mainThemeSource.Play();
        _background.sprite = _backBad;
        characterName.text = "Надія ";
        SetCharacterSprite(_currentMessage.character, false);
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 19");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepTwenty()
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
            Debug.Log("End Text 20");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepTwentyOne()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Надія ";
        SetCharacterSprite(_currentMessage.character, false);
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 20");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepTwentyTwo()
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
            Debug.Log("End Text 20");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepTwentyThree()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Надія ";
        SetCharacterSprite(_currentMessage.character, false);
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 20");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepTwentyFour()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Надія ";
        SetCharacterSprite(_currentMessage.character, false);
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 20");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepTwentyFive()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Надія ";
        SetCharacterSprite(_currentMessage.character, false);
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 20");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepTwentySix()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Надія ";
        SetCharacterSprite(_currentMessage.character, false);
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 20");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepTwentySeven()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Ви ";
        SetChooseButton(_currentMessage.text, model =>
        {
            currentStep = _currentMessage.id;
            OnButtonClick();
        });
    }
    
    private IEnumerator StepTwentyEight()
    {
        isCanTap = false;
        //музыка
        // settings.mainThemeSource.clip = _actSound[4];
        // settings.mainThemeSource.Play();
        AnimateImageShow(_foreground, 0);
        AnimateImageHide(_character, 0);
        _background.sprite = _finalSprite;
        yield return new WaitForSeconds(3);
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        AnimateImageHide(_foreground, 0);
        yield return new WaitForSeconds(10);
        //Show titre
        isActEnd = true;
    }
}