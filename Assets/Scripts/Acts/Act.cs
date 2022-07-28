using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Act : MonoBehaviour
{
    [SerializeField] public Image _background;
    [SerializeField] public Image _character;
    [SerializeField] public int _id;
    [SerializeField] public AudioClip _actMusic;
    [SerializeField] public List<AudioClip> _actSound;
    [SerializeField] public MessageModel _startMessage;
    [SerializeField] public MessageModel _currentMessage;
    [SerializeField] public Text characterName;
    [SerializeField] public Text characterSay;
    [SerializeField] public List<Button> buttons;
    [SerializeField] public bool canTap;
    [SerializeField] public float tapingDelay;
    [SerializeField] public Settings settings;
    [SerializeField] public GameObject choosePanel;
    
    protected int currentStep = 0;
    protected bool _textFull;
    protected IEnumerator _currentCoroutine;
    
    private bool isActEnd;

    public virtual void StartAct(Action endCallback)
    {
        _currentMessage = _startMessage;
        isActEnd = false;
        currentStep = 0;
        StartCoroutine(ActEnd(endCallback));
    }
    
    protected virtual void OnButtonClick()
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
                isActEnd = true;
                return;
            }
            currentStep = _currentMessage.nextMessage[0].id;
            NextStep();
        }
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

    protected void SetCharacterSprite(Sprite characterSprite)
    {
        _character.gameObject.SetActive(true);
        _character.sprite = characterSprite;
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
            finalMessage.Invoke(_currentMessage.nextMessage[0].nextMessage[0]);
            ClearButtonsListener();
        });
        buttons[2].onClick.AddListener(()=>
        {
            AddPoint(relationPoint2);
            choosePanel.SetActive(false);
            buttons[0].gameObject.SetActive(true);
            finalMessage.Invoke(_currentMessage.nextMessage[1].nextMessage[0]);
            ClearButtonsListener();
        });
        buttons[3].onClick.AddListener(()=>
        {
            AddPoint(relationPoint3);
            choosePanel.SetActive(false);
            buttons[0].gameObject.SetActive(true);
            finalMessage.Invoke(_currentMessage.nextMessage[2].nextMessage[0]);
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
}
