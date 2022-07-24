using System;
using System.Collections;
using UnityEngine;

public class Act1 : Act
{
    public override void StartAct(Action endCallback)
    {
        StartCoroutine(ActOne(endCallback));
    }

    private IEnumerator ActOne(Action endCallback)
    {
        yield return new WaitForSeconds(1);
        Debug.Log("End Act 1");
        endCallback.Invoke();
    }
}
