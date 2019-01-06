﻿using System;
using UnityEngine;

public static class TransformExtensions
{
    public static Tweener MoveTo(this Transform t, Vector3 position)
    {
        return MoveTo(t, position, Tweener.DefaultDuration);
    }

    public static Tweener MoveTo(this Transform t, Vector3 position, float duration)
    {
        return MoveTo(t, position, duration, Tweener.DefaultEquation);
    }

    public static Tweener MoveTo(this Transform t, Vector3 position, float duration, Func<float, float, float, float> equation)
    {
        TransformPositionTweener tweener = t.gameObject.AddComponent<TransformPositionTweener>();
        tweener.startValue = t.position;
        tweener.endValue = position;
        tweener.easingControl.duration = duration;
        tweener.easingControl.equation = equation;
        tweener.easingControl.Play();
        return tweener;
    }

    public static Tweener MoveToLocal(this Transform t, Vector3 position)
    {
        return MoveToLocal(t, position, Tweener.DefaultDuration);
    }

    public static Tweener MoveToLocal(this Transform t, Vector3 position, float duration)
    {
        return MoveToLocal(t, position, duration, Tweener.DefaultEquation);
    }

    public static Tweener MoveToLocal(this Transform t, Vector3 position, float duration, Func<float, float, float, float> equation)
    {
        TransformLocalPositionTweener tweener = t.gameObject.AddComponent<TransformLocalPositionTweener>();
        tweener.startValue = t.localPosition;
        tweener.endValue = position;
        tweener.easingControl.duration = duration;
        tweener.easingControl.equation = equation;
        tweener.easingControl.Play();
        return tweener;
    }

    public static Tweener ScaleTo(this Transform t, Vector3 scale)
    {
        return ScaleTo(t, scale, Tweener.DefaultDuration);
    }

    public static Tweener ScaleTo(this Transform t, Vector3 scale, float duration)
    {
        return ScaleTo(t, scale, duration, Tweener.DefaultEquation);
    }

    public static Tweener ScaleTo(this Transform t, Vector3 scale, float duration, Func<float, float, float, float> equation)
    {
        TransformScaleTweener tweener = t.gameObject.AddComponent<TransformScaleTweener>();
        tweener.startValue = t.localScale;
        tweener.endValue = scale;
        tweener.easingControl.duration = duration;
        tweener.easingControl.equation = equation;
        tweener.easingControl.Play();
        return tweener;
    }

    public static Tweener RotateTo(this Transform t, Vector3 rotation)
    {
        return RotateTo(t, rotation, Tweener.DefaultDuration);
    }

    public static Tweener RotateTo(this Transform t, Vector3 rotation, float duration)
    {
        return RotateTo(t, rotation, duration, Tweener.DefaultEquation);
    }

    public static Tweener RotateTo(this Transform t, Vector3 rotation, float duration, Func<float, float, float, float> equation)
    {
        TransformEulerAnglesTweener tweener = t.gameObject.AddComponent<TransformEulerAnglesTweener>();
        tweener.startValue = t.eulerAngles;
        tweener.endValue = rotation;
        tweener.easingControl.duration = duration;
        tweener.easingControl.equation = equation;
        tweener.easingControl.Play();
        return tweener;
    }

    public static Tweener RotateToLocal(this Transform t, Vector3 rotation)
    {
        return RotateToLocal(t, rotation, Tweener.DefaultDuration);
    }

    public static Tweener RotateToLocal(this Transform t, Vector3 rotation, float duration)
    {
        return RotateToLocal(t, rotation, duration, Tweener.DefaultEquation);
    }

    public static Tweener RotateToLocal(this Transform t, Vector3 rotation, float duration, Func<float, float, float, float> equation)
    {
        TransformLocalEulerAnglesTweener tweener = t.gameObject.AddComponent<TransformLocalEulerAnglesTweener>();
        tweener.startValue = t.localEulerAngles;
        tweener.endValue = rotation;
        tweener.easingControl.duration = duration;
        tweener.easingControl.equation = equation;
        tweener.easingControl.Play();
        return tweener;
    }

}
