using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Act : MonoBehaviour
{
    [SerializeField] public Image _background;
    [SerializeField] public Image _foreground;
    [SerializeField] public Image _blur;
    [SerializeField] public Image _character;
    [SerializeField] public int _id;
    [SerializeField] public AudioClip _actMusic;
    [SerializeField] public List<AudioClip> _actSound;
    [SerializeField] public MessageModel _startMessage;
    [SerializeField] public MessageModel _currentMessage;
    [SerializeField] public Text characterName;
    [SerializeField] public Text characterSay;
    [SerializeField] public List<Font> fontForText;
    [SerializeField] public List<Button> buttons;
    [SerializeField] public float tapingDelay;
    [SerializeField] public Settings settings;
    [SerializeField] public GameLogic gameLogic;
    [SerializeField] public GameObject choosePanel;
    
    protected int currentStep = 0;
    protected IEnumerator _currentCoroutine;
    
    protected bool _textFull;
    protected bool isActEnd;
    protected bool isCanTap;


    public virtual void StartAct(Action endCallback)
    {
        _currentMessage = _startMessage;
        isActEnd = false;
        currentStep = 0;
        StartCoroutine(ActEnd(endCallback));
    }
    
    public virtual void OnButtonClick()
    {
        if (isCanTap)
        {
            if (CheckIsRoutinePlay())
            {
                StopCoroutine(_currentCoroutine);
                characterSay.text = _currentMessage.text;
                _textFull = true;
            }
            else
            {
                if (_currentMessage.nextMessage.Count == 0)
                {
                    StartCoroutine(EndAction());
                    return;
                }
                currentStep = _currentMessage.nextMessage[0].id;
                NextStep();
            }
        }
    }

    private IEnumerator EndAction()
    {
        _foreground.gameObject.SetActive(true);
        settings.mainThemeSource.Stop();
        settings.soundThemeSource.Stop();
        yield return new WaitForSeconds(2);
        isActEnd = true;
    }

    private bool CheckIsRoutinePlay()
    {
        return !_textFull;
    }
    
    protected virtual void NextStep()
    {
    }

    private IEnumerator ActEnd(Action endCallback)
    {
        yield return new WaitUntil((() => isActEnd));
        Debug.Log("End Act");
        gameObject.SetActive(false);
        endCallback.Invoke();
    }

    protected IEnumerator ShowText(string fullText, Action endCallback)
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            var currentText = fullText.Substring(0, i);
            characterSay.text = currentText;
            yield return new WaitForSeconds(tapingDelay);
        }
        endCallback.Invoke();
    }

    protected void SetCharacterSprite(Sprite characterSprite, bool isAlphaZero)
    {
        _character.gameObject.SetActive(true);
        _character.sprite = characterSprite;
        var characterColor = _character.color;
        if (isAlphaZero) return;
        characterColor.a = 1f;
        _character.color = characterColor;
    }
    
    protected void HideCharacter()
    {
        _character.gameObject.SetActive(false);
        _character.sprite = null;
    }
    
    protected void SetChooseButton(string choose1Text, int relationPoint1, string choose2Text, int relationPoint2, string choose3Text, int relationPoint3, Action<MessageModel> finalMessage)
    {
        choosePanel.SetActive(true);
        buttons[0].gameObject.SetActive(false);
        buttons[1].GetComponentInChildren<Text>().text = choose1Text;
        buttons[2].GetComponentInChildren<Text>().text = choose2Text;
        buttons[3].GetComponentInChildren<Text>().text = choose3Text;
        buttons[1].onClick.AddListener(()=>
        {
            AddPoint(relationPoint1);
            choosePanel.SetActive(false);
            buttons[0].gameObject.SetActive(true);
            finalMessage.Invoke(_currentMessage.nextMessage[0]);
            ClearButtonsListener();
        });
        buttons[2].onClick.AddListener(()=>
        {
            AddPoint(relationPoint2);
            choosePanel.SetActive(false);
            buttons[0].gameObject.SetActive(true);
            finalMessage.Invoke(_currentMessage.nextMessage[1]);
            ClearButtonsListener();
        });
        buttons[3].onClick.AddListener(()=>
        {
            AddPoint(relationPoint3);
            choosePanel.SetActive(false);
            buttons[0].gameObject.SetActive(true);
            finalMessage.Invoke(_currentMessage.nextMessage[2]);
            ClearButtonsListener();
        });
    }

    private void ClearButtonsListener()
    {
        buttons[1].onClick.RemoveAllListeners();
        buttons[2].onClick.RemoveAllListeners();
        buttons[3].onClick.RemoveAllListeners();
    }

    private void AddPoint(int point)
    {
        var currentPoint = PlayerPrefsSaveSystem.LoadPlayerRelationSheepPoint();
        currentPoint += point;
        PlayerPrefsSaveSystem.SetPlayerRelationSheepPoint(currentPoint);
    }
    
    protected void AnimateImageShow(Image image, int duration)
    {
        image.gameObject.SetActive(true);
        var imageColor = image.color;
        imageColor.a = 0;
        image.color = imageColor;
        imageColor.a = 1;
        DOTween.To(() => image.color, value => image.color = value, imageColor, duration);
    }
    
    protected void AnimateImageHide(Image image, int duration)
    {
        image.gameObject.SetActive(true);
        var imageColor = image.color;
        imageColor.a = 1;
        image.color = imageColor;
        imageColor.a = 0;
        DOTween.To(() => image.color, value =>
        {
            image.color = value;
        }, imageColor, duration).OnComplete(() => image.gameObject.SetActive(false));
    }
    
    protected void AnimateObjectShaking(Transform transform, int duration)
    {
        transform.DOShakePosition(duration, 2f);
    }
    
    protected void StopObjectTween(Transform transform)
    {
        DOTween.Kill(transform);
    }
    
    protected void AnimateObjectScaleUp(Transform transform, int duration)
    {
        var newScale = new Vector3(2, 2, 1);
        DOTween.To(() => transform.localScale, value =>
        {
            transform.localScale = value;
        }, newScale, duration);
    }
    
    protected void BackObjectScale(Transform transform)
    {
        transform.localScale = Vector3.one;
    }
}
