using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Act0 : Act
{
    [SerializeField] public Image _smoke;
    public override void StartAct()
    {
        base.StartAct();
        StartCoroutine(ActZero());
    }

    private IEnumerator ActZero()
    {
        Debug.Log("Start Play 'Вибух. Тяжкий подих. Серцебиття'");
        yield return new WaitForSeconds(1);
        _smoke.gameObject.SetActive(true);
        var smokeColor = _smoke.color;
        smokeColor.a = 0;
        _smoke.color = smokeColor;
        yield return new WaitForSeconds(1);
        smokeColor.a = 0.5f;
        _smoke.color = smokeColor;
        yield return new WaitForSeconds(2);
        smokeColor.a = 1;
        _smoke.color = smokeColor;
    }
}
