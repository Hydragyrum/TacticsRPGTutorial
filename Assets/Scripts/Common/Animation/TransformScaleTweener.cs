using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScaleTweener : Vector3Tweener
{
    protected override void OnComplete(object sender, EventArgs e)
    {
        base.OnComplete(sender, e);
        transform.localScale = currentValue;
    }
}
