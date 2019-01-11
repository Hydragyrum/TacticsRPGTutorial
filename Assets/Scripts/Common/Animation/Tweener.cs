using System;
using UnityEngine;

public abstract class Tweener : MonoBehaviour
{
    #region Properties
    public static float DefaultDuration = 1.0f;
    public static Func<float, float, float, float> DefaultEquation = EasingFunctions.EaseInOutQuad;

    public EasingControl easingControl;
    public bool destroyOnComplete = true;
    #endregion

    #region MonoBehaviour

    protected virtual void Awake()
    {
        easingControl = gameObject.AddComponent<EasingControl>();
    }

    protected virtual void OnEnable()
    {
        easingControl.updateEvent += OnUpdate;
        easingControl.completedEvent += OnComplete;
    }

    protected virtual void OnDisable()
    {
        easingControl.updateEvent -= OnUpdate;
        easingControl.completedEvent -= OnComplete;
    }

    protected virtual void OnDestroy()
    {
        if(easingControl != null)
        {
            Destroy(easingControl);
        }
    }
    #endregion

    #region EventHandlers
    protected abstract void OnUpdate(object sender, EventArgs e);

    protected virtual void OnComplete(object sender, EventArgs e)
    {
        if(destroyOnComplete)
        {
            Destroy(this);
        }
    }
    #endregion
}
