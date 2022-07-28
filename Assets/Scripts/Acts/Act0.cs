using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Act0 : Act
{
    [SerializeField] public Image _smoke;
    [SerializeField] public Image _foreground;
    public override void StartAct(Action endCallback)
    {
        base.StartAct(endCallback);
        StartCoroutine(ActZero());
    }

    private IEnumerator ActZero()
    {
        settings.soundThemeSource.clip = _actSound[0];
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(4);
        settings.soundThemeSource.clip = _actSound[1];
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(4);
        AnimateImageShow(_smoke, 7);
        settings.soundThemeSource.clip = _actSound[2];
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(7);
        settings.soundThemeSource.clip = _actSound[3];
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(9);
        settings.soundThemeSource.clip = _actSound[4];
        settings.soundThemeSource.Play();
        AnimateImageShow(_foreground, 4);
        yield return new WaitForSeconds(1);
        settings.soundThemeSource.clip = _actSound[5];
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(1);
        settings.soundThemeSource.clip = _actSound[6];
        settings.soundThemeSource.Play();
        yield return new WaitForSeconds(2);
        isActEnd = true;
    }
}
