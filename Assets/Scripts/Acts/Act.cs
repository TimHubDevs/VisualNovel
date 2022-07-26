using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] public float speedTaping;
    [SerializeField] public Settings settings;
    [SerializeField] public GameObject choosePanel;
    protected int currentStep = 0;
    protected bool isActEnd;
    
    public virtual void StartAct(Action endCallback)
    {
        _currentMessage = _startMessage;
        isActEnd = false;
        currentStep = 0;
    }

    protected IEnumerator ShowText(string fullText, Action endCallback)
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            var currentText = fullText.Substring(0, i);
            characterSay.text = currentText;
            yield return new WaitForSeconds(speedTaping);
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
}
