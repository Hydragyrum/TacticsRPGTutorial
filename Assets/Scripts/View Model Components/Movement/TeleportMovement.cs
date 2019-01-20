﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMovement : Movement
{
    public override IEnumerator Traverse(Tile tile)
    {
        unit.Place(tile);
        Tweener spin = jumper.RotateToLocal(new Vector3(0, 360, 0), 0.5f, EasingFunctions.EaseInOutQuad);
        spin.easingControl.loopCount = 1;
        spin.easingControl.loopType = EasingControl.LoopType.PingPong;

        Tweener shrink = transform.ScaleTo(Vector3.zero, 0.5f, EasingFunctions.EaseInBack);
        while (shrink != null)
        {
            yield return null;
        }

        transform.position = tile.centre;

        Tweener grow = transform.ScaleTo(Vector3.one, 0.5f, EasingFunctions.EaseOutBack);
        while (grow != null)
        {
            yield return null;
        }
    }
}
