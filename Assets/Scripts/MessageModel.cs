using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageModel : MonoBehaviour
{
    [TextArea(7, 30)] [SerializeField] public string text;
    [SerializeField] public CharacterType characterType;
    [SerializeField] public Sprite character;
    [SerializeField] public bool showCharacter;
    [SerializeField] public int relationPoint;
    [SerializeField] public List<MessageModel> nextMessage;
}
