using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEulerAnglesTweener : Vector3Tweener
{
    protected override void OnUpdate(object sender, EventArgs e)
    {
        base.OnUpdate(sender, e);
        transform.eulerAngles = currentValue;
    }
}
