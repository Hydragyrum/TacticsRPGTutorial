using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Tile tile { get; protected set; }
    public Directions dir;

    public void Place(Tile target)
    {
        //Clear old location
        if (tile != null && tile.content == gameObject)
        {
            tile.content = null;
        }

        tile = target;

        if (target != null)
        {
            target.content = gameObject;
        }
    }

    public void Match()
    {
        transform.localPosition = tile.centre;
        transform.localEulerAngles = dir.ToEuler();
    }
}
