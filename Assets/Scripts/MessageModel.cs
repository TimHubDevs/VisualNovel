using System.Collections.Generic;
using UnityEngine;

public class MessageModel : MonoBehaviour
{
    [SerializeField] public int id;
    [TextArea(7, 30)] [SerializeField] public string text;
    [SerializeField] public CharacterType characterType;
    [SerializeField] public Sprite character;
    [SerializeField] public bool showCharacter;
    [SerializeField] public int relationPoint;
    [SerializeField] public List<MessageModel> nextMessage;
}
