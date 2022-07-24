using System;
using System.Collections;
using UnityEngine;

public class Act1 : Act
{
    private MessageModel currentMessage;
    public override void StartAct(Action endCallback)
    {
        Debug.Log("Music 'Theme Act 1'continue");
        // buttons[0].onClick.AddListener(OnButtonCkick);
        StartCoroutine(ActOne(endCallback));
    }

    private void OnButtonCkick()
    {
        onTapNext.Invoke();
    }

    private IEnumerator ActOne(Action endCallback)
    {
        canTap = false;
        text.text = String.Empty;
        Debug.Log("Sound 'Бубоніння людей. Тріск від пожежі. Тривожна музика'");
        yield return new WaitForSeconds(3);
        currentMessage = _messageModel;
        _character.sprite = currentMessage.character;
        string fullText = currentMessage.text;
        StartCoroutine(ShowText(fullText, "<b>Рятувальник: </b>", () =>
        {
            text.text += "\n";
            Debug.Log("end text1");
            currentMessage = currentMessage.nextMessage[0];
            fullText = currentMessage.text;
            StartCoroutine(ShowText(fullText, "<b>ГГ: </b>", () =>
            {
                text.text += "\n";
                Debug.Log("end text 2");
            }));
            //animate after show next
            // yield return new WaitForSeconds(2);
            // currentMessage = currentMessage.nextMessage[0];
            // text.text = "<b>ГГ: </b>" + currentMessage.text;
            // yield return new WaitForSeconds(2);
            // currentMessage = currentMessage.nextMessage[0];
            // text.text = "<b>Рятувальник: </b>" + currentMessage.text;
            // yield return new WaitForSeconds(5);
            // Debug.Log("End Act 1");
            // endCallback.Invoke();
        }));
    }
}
