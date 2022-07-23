using UnityEngine;
using UnityEngine.UI;

public class Act : MonoBehaviour
{
    [SerializeField] public Image _background;
    
    public virtual void StartAct()
    {
        Debug.Log("Start Act");
    }
}
