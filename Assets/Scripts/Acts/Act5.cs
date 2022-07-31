using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Act5 : Act
{
    [SerializeField] private Image _foregroundWithText;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GameObject _particleSystemGameObject;
    private int chosenStep;
    
    public override void StartAct(Action endCallback)
    {
        base.StartAct(endCallback);
        StartCoroutine(StepZero());
    }

    private IEnumerator StepZero()
    {
        isCanTap = false;
        AnimateImageShow(_foregroundWithText, 0);
        _particleSystemGameObject.SetActive(true);
        _particleSystem.Play();
        characterSay.font = fontForText[1];
        settings.mainThemeSource.clip = _actMusic;
        settings.soundThemeSource.clip = _actSound[0];
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(8);
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
                StartCoroutine(StepOne());
                break;
            case 2:
                StartCoroutine(StepTwo());
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
                StartCoroutine(StepEleven());
                break;
        }
    }

    private IEnumerator StepOne()
    {
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        settings.soundThemeSource.clip = _actSound[1];
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(4);
        settings.mainThemeSource.Play();
        _particleSystem.Stop();
        AnimateImageHide(_foregroundWithText, 4);
        AnimateObjectDistorb(_background.transform, 10);
        yield return new WaitForSeconds(4);
        _particleSystemGameObject.SetActive(false);
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Ви ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 1");
        });
        StartCoroutine(_currentCoroutine);
        isCanTap = true;
    }

    private IEnumerator StepTwo()
    {
        AnimateImageShow(_foregroundWithText, 0);
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        settings.soundThemeSource.clip = _actSound[1];
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(4);
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "??? ";
        characterSay.font = fontForText[0];
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 2");
        });
        StartCoroutine(_currentCoroutine);
        isCanTap = true;
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
            Debug.Log("End Text 3");
        });
        StartCoroutine(_currentCoroutine);
    }
    
    private void StepFour()
    {
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        AnimateImageHide(_foregroundWithText, 0);
        StopObjectTween(_background.transform);
        _currentMessage = _currentMessage.nextMessage[0];
        SetCharacterSprite(_currentMessage.character, false);
        characterName.text = "Дід ";
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
        characterName.text = "Дід ";
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
        characterName.text = "Дід ";
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
        settings.soundThemeSource.clip = _actSound[2];
        settings.soundThemeSource.Play();
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Дід ";
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
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        _currentMessage = _currentMessage.nextMessage[0];
        characterName.text = "Дід ";
        _currentCoroutine = ShowText(_currentMessage.text, () =>
        {
            _textFull = true;
            currentStep++;
            Debug.Log("End Text 11");
        });
        StartCoroutine(_currentCoroutine);
        isCanTap = true;
    }

    private IEnumerator StepEleven()
    {
        AnimateImageHide(_character, 0);
        isCanTap = false;
        _textFull = false;
        characterName.text = String.Empty;
        characterSay.text = String.Empty;
        settings.soundThemeSource.clip = _actSound[1];
        settings.soundThemeSource.Play();
        AnimateImageShow(_foregroundWithText, 3);
        yield return new WaitForSeconds(4);
        isActEnd = true;
    }
}