using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _dash;
   
    public void PushMusicButton()
    {
        _dash.SetActive(!_dash.activeInHierarchy);
    }

    public void PushSoundButton()
    {
        _dash.SetActive(!_dash.activeInHierarchy); 
    }

    

    
}