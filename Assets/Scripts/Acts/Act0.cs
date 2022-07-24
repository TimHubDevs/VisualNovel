using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Act0 : Act
{
    [SerializeField] public Image _smoke;
    [SerializeField] public Image _foreground;
    public override void StartAct(Action endCallback)
    {
        Debug.Log("Music 'Theme Act 1'");
        StartCoroutine(ActZero(endCallback));
    }

    private IEnumerator ActZero(Action endCallback)
    {
        Debug.Log("Sound 'Вибух. Тяжкий подих. Серцебиття'");
        yield return new WaitForSeconds(1);
        AnimateImageShow(_smoke);
        yield return new WaitForSeconds(4);
        Debug.Log("Sound 'Тупотіння, Збігає вниз. Додаємо тривожну музику.'");
        yield return new WaitForSeconds(1);
        AnimateImageShow(_foreground);
        yield return new WaitForSeconds(4);
        Debug.Log("End Act 0");
        endCallback.Invoke();
    }

    private void AnimateImageShow(Image image)
    {
        image.gameObject.SetActive(true);
        var imageColor = image.color;
        imageColor.a = 0;
        image.color = imageColor;
        imageColor.a = 1;
        DOTween.To(() => image.color, value => image.color = value, imageColor, 3);
    }
}
