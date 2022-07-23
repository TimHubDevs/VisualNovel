using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private List<Act> _acts;

    public void StartPlay()
    {
        _acts[0].gameObject.SetActive(true);
        _acts[0].StartAct();
    }
    
    public void LoadPlay()
    {
        // load and play act in save system
    }
    
    public void HideAct()
    {
        // set act active false
    }
}
